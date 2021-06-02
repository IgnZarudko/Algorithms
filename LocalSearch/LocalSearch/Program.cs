using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalSearch
{
    internal static class Program
    {
        private static void Main()
        {
            const int size = 10;
            const int maxValue = 75;
            
            var weightsMatrix = WeightsMatrix(size, maxValue);
            var solver = new SalesmenSolver(weightsMatrix);
            
            PrintMatrix(weightsMatrix);
                
            solver.Search();
        }
        
        private static List<List<int>> WeightsMatrix(int size, int maxValue)
        {
            var random = new Random();
            var weights = new List<List<int>>();
            
            for (int i = 0; i < size; i++)
            {
                weights.Add(new List<int>());
                for (var j = 0; j < size; j++)
                {
                    weights[i].Add(random.Next(1, maxValue));
                }
            }

            for (int i = 1; i < size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    weights[i][j] = weights[j][i];
                }
            }
                

            return weights;
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            Console.WriteLine("Weights matrix:");

            var maxWidthOfNumber = matrix
                .Max(line => line.Max())
                .ToString()
                .Length + 1;

            foreach (var line in matrix)
            {
                foreach (int value in line)
                {
                    Console.Write($"{{0, {maxWidthOfNumber}}}", (value == int.MaxValue) ? "M" : value.ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
