using System;

namespace GeneticAlgorithm
{
    class Program
    {
        private static GeneticSolver.TargetEquation _equation = TargetEquations.TargetB;
        
        private const int POPULATION_SIZE = 4000;
        private const int MIN_VALUE = -200;
        private const int MAX_VALUE = 200;
        private const int SELECTION_AMOUNT = 2000;
        private const int CHILDREN_AMOUNT = 5000;
        private const int MUTANTS_AMOUNT = 1000;
        private const double MUTATION_POSSIBILITY = 0.5;
        private const double SUBSTITUTION_POSSIBILITY = 0.5;

        static void Main(string[] args)
        {
            GeneticSolver solver = new GeneticSolver(
                _equation,
                POPULATION_SIZE, 
                MIN_VALUE, 
                MAX_VALUE, 
                SELECTION_AMOUNT, 
                CHILDREN_AMOUNT,
                MUTANTS_AMOUNT, 
                MUTATION_POSSIBILITY, 
                SUBSTITUTION_POSSIBILITY
                );

            SolutionVector solutionVector = solver.Execute();
            
            Console.WriteLine(solver.Log());
            Console.WriteLine(solutionVector.ToString());
        }
    }
}

//Уравнение 1: -13 + ((w^2) * x * y) + (x * (y^2)) + z + ((u^2) * (w^2) * x * y * z) + (w * x * y * (z^2))

//Уравнение 2: 50 + x + y + (u * w * x * y) + ((u^2) * w * x * y) + (u * x * y * (z^2))

//Начальная популяция: Случайная в (-200,200)

//Селекция: Случайная

//Скрещивание: "Одноточечная (в третьем гене) + многоточечная (во втором и четвертом гене)"

//Мутация: "Каждый бит некоторых наименее 
// пригодных потомков 
// мутирует с некоторой 
//     вероятностью p"

//Замещение: "Произвести больше потомков, и оставить 
// популяцию такого же размера, как старая, 
// но состоящую исключительно из более 
// пригодных потомков"