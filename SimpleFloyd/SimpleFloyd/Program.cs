using System;
using System.Linq;

namespace SimpleFloyd
{
    class Program
    {
        static void Main(string[] args)
        {
            int inf = Int32.MaxValue;
            
            int[][] graphMatrix = new[]
            //         s a b c d e f t
            {
                new[] {inf, inf, 6, inf, inf, inf, inf, inf}, //s
                new[] {-6, inf, 4, inf, 1, inf, inf, inf}, //a
                new[] {-6, inf, inf, 6, inf, inf, inf, inf}, //b
                new[] {-3, inf, inf, inf, inf, 4, -8, inf}, //c
                new[] {inf, -1, -6, inf, inf, 7, inf, 8}, //d
                new[] {inf, 1, inf, inf, inf, inf, inf, 4}, //e
                new[] {inf, inf, inf, -8, inf, 7, inf, 1}, //f
                new[] {inf, inf, inf, inf, -8, inf, -1, inf} //t
            };
            
            int[][] ways = new[]
            {
                new[] {0, 1, 2, 3, 4, 5, 6, 7},
                new[] {0, 1, 2, 3, 4, 5, 6, 7},
                new[] {0, 1, 2, 3, 4, 5, 6, 7},
                new[] {0, 1, 2, 3, 4, 5, 6, 7},
                new[] {0, 1, 2, 3, 4, 5, 6, 7},
                new[] {0, 1, 2, 3, 4, 5, 6, 7},
                new[] {0, 1, 2, 3, 4, 5, 6, 7},
                new[] {0, 1, 2, 3, 4, 5, 6, 7}
            };
            
            FloydAlgorithm(graphMatrix, ways);

            for (int i = 0; i < graphMatrix.Length; i++)
            {
                foreach (var distance in graphMatrix[i])
                {
                    int toWrite = distance == inf ? 9999 : distance;
                    Console.Write(toWrite + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < ways.Length; i++)
            {
                foreach (var way in ways[i])
                {
                    Console.Write(way + " ");
                }
                Console.WriteLine();
            }
        }
        
        private static void FloydAlgorithm(int[][] matrix, int[][] ways)
        {
            int amountOfCrossroads = matrix.Length;

            for (int k = 0; k < amountOfCrossroads; k++)
            {
                for (int i = 0; i < amountOfCrossroads; i++)
                {
                    if (i != k)
                    {
                        for (int j = 0; j < amountOfCrossroads; j++)
                        {
                            if (j != k)
                            {
                                if (matrix[i][j] > matrix[k][j] + matrix[i][k])
                                {
                                    matrix[i][j] = matrix[k][j] + matrix[i][k];
                                    ways[i][j] = ways[i][k];
                                }
                            }
                        }   
                    }
                    if (matrix[i][i] < 0) return;
                }
            }
        }
        
        
    }
}
