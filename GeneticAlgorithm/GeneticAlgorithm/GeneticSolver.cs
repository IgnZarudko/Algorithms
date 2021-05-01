using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm
{
    public class GeneticSolver
    {
        private static readonly StringBuilder LogStringBuilder = new StringBuilder();
        private static readonly Random Random = new ();
        private static int GetBorderForCrossovers() => Random.Next(3) + 1;

        private static (SolutionVector, SolutionVector) OnePointCross(SolutionVector first, SolutionVector second)
        {
            int border = GetBorderForCrossovers();

            SolutionVector newFirst = first.Clone();
            for (var i = border; i < SolutionVector.Count; i++)
            {
                newFirst[i] = second[i];
            }
            
            SolutionVector newSecond = second.Clone();
            for (var i = border; i < SolutionVector.Count; i++)
            {
                newSecond[i] = first[i];
            }

            return (newFirst, newSecond);
        }
        
        private static (SolutionVector, SolutionVector) MultiPointCross(SolutionVector first, SolutionVector second)
        {
            var (borderOne, borderTwo) = (GetBorderForCrossovers(), GetBorderForCrossovers());
            var borderMin = Math.Min(borderOne, borderTwo);
            var borderMax = Math.Max(borderOne, borderTwo);

            var newFirst = first.Clone();
            for (var i = borderMin; i <= borderMax; i++)
                newFirst[i] = second[i];
            
            var newSecond = second.Clone();
            for (var i = borderMin; i <= borderMax; i++)
                newSecond[i] = first[i];

            return (newFirst, newSecond);
        }

        public delegate int TargetEquation(SolutionVector solutionVector);

        private readonly TargetEquation _targetEquation;
        
        private readonly int _populationSize;
        
        private readonly int _minValue;
        private readonly int _maxValue;
        
        private readonly int _selectionAmount;
        private readonly int _childrenAmount;
        private readonly int _mutantsAmount;
        
        private readonly double _mutationPossibility;
        private readonly double _substitutionPossibility;

        private List<SolutionVector> _population;

        public GeneticSolver(
            TargetEquation targetEquation, 
            int populationSize, 
            int minValue, 
            int maxValue, 
            int selectionAmount, 
            int childrenAmount,
            int mutantsAmount, 
            double mutationPossibility, 
            double substitutionPossibility
            )
        {
            _targetEquation = targetEquation;
            _populationSize = populationSize;
            _minValue = minValue;
            _maxValue = maxValue;
            _selectionAmount = selectionAmount;
            _childrenAmount = childrenAmount;
            _mutantsAmount = mutantsAmount;
            _mutationPossibility = mutationPossibility;
            _substitutionPossibility = substitutionPossibility;

            LogStringBuilder.Append("Initializing Start Population... \n");
            InitializeStartPopulation();
        }

        public SolutionVector Execute()
        {
            for (int generation = 1;; generation++)
            {
                List<SolutionVector> selectedVectors = SelectRandomVectors();
                List<SolutionVector> childValues = GenerateChildren(selectedVectors, generation % 2 == 0);
                
                MutateUnsuitable(childValues);

                childValues = childValues
                    .OrderBy(value => _targetEquation(value))
                    .Take(_populationSize)
                    .ToList();

                LogStringBuilder.AppendLine($"Generation {generation}");
                LogStringBuilder.AppendLine($"Using multi-point crossover: {generation % 2 == 0}");
                LogStringBuilder.AppendLine($"Closest solution vector: {childValues[0]}");
                LogStringBuilder.AppendLine($"How far: {_targetEquation(childValues[0])}");

                if (_targetEquation(childValues[0]) == 0)
                {
                    LogStringBuilder.AppendLine($"Solution Vector found: {childValues[0]}");
                    return childValues[0];
                }

                LogStringBuilder.AppendLine("Replacing population with new one");
                LogStringBuilder.AppendLine("-----------------------------------------");
                _population = childValues;
            }
        }

        public string Log()
        {
            return LogStringBuilder.ToString();
        }

        private List<SolutionVector> SelectRandomVectors()
        {
            return _population
                .OrderBy(vec => Random.NextDouble())
                .Take(_selectionAmount)
                .ToList();
        }

        private void MutateUnsuitable(List<SolutionVector> children)
        {
            var selected = children
                .OrderByDescending(value => _targetEquation(value))
                .Take(_mutantsAmount);
            
            foreach (var mutant in selected)
            {
                for (int j = 0; j < SolutionVector.Count; j++)
                {
                    if (Random.NextDouble() >= _mutationPossibility)
                    {
                        mutant[j] = RandomValue();
                    }
                }
            }
        }
        
        private List<SolutionVector> GenerateChildren(List<SolutionVector> parentSolutions, bool useMultiPoint)
        {
            List<SolutionVector> childrenSolutions = new List<SolutionVector>();

            for (int i = 0; i <= _childrenAmount; i++)
            {
                var (firstParent, secondParent) = (Random.Next(parentSolutions.Count), Random.Next(parentSolutions.Count));
                
                var (childFirst, childSecond) = useMultiPoint
                    ? OnePointCross(parentSolutions[firstParent], parentSolutions[secondParent])
                    : MultiPointCross(parentSolutions[firstParent], parentSolutions[secondParent]);
                
                childrenSolutions.Add(childFirst);
                childrenSolutions.Add(childSecond);
            }

            return childrenSolutions;
        }

            private void InitializeStartPopulation()
        {
            _population = new List<SolutionVector>();
            for (int i = 0; i < _populationSize; i++)
            {
                _population.Add(GenerateSolutionVector());
            }
        }

        private SolutionVector GenerateSolutionVector()
        {
            return new SolutionVector(RandomValue(), RandomValue(), RandomValue(), RandomValue(), RandomValue());
        }

        private int RandomValue() => Random.Next(_minValue, _maxValue);

    }
}