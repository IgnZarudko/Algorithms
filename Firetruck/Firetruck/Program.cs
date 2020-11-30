using System;
using System.Collections.Generic;
using System.Text;

namespace Firetruck
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayInfoFloyd();
            
            DisplayInfoDijkstra();
        }

        private static void DisplayInfoDijkstra()
        {
            int[][] roadMap = new[]
            {
                new[] {Int32.MaxValue, 4, 1, 3, 1},
                new[] {4, Int32.MaxValue, 3, 2, 1},
                new[] {1, 3, Int32.MaxValue, 5, 4},
                new[] {3, 2, 5, Int32.MaxValue, 0},
                new[] {1, 1, 4, 0, Int32.MaxValue}
            };
            
            FireTruckStationBuilderFloyd builder = new FireTruckStationBuilderFloyd(roadMap);
            (int crossroad, List<List<int>> ways) = builder.SuitableCrossroad();
            
            Console.Out.WriteLine($"Suitable crossroad is number {crossroad}");
            for (int i = 0; i < ways.Count; i++)
            {
                if (ways[i] != null)
                {
                    StringBuilder sb = new StringBuilder("Way to " + i + " : ");
                    foreach (int point in ways[i])
                    {
                        sb.Append($"{point}->");   
                    }

                    sb.Remove(sb.Length - 2, 2);
                    Console.WriteLine(sb.ToString());
                }
            }
        }

        private static void DisplayInfoFloyd()
        {
            int[][] roadMap = new[]
            {
                new[] {Int32.MaxValue, 4, 1, 3, 1},
                new[] {4, Int32.MaxValue, 3, 2, 1},
                new[] {1, 3, Int32.MaxValue, 5, 4},
                new[] {3, 2, 5, Int32.MaxValue, 0},
                new[] {1, 1, 4, 0, Int32.MaxValue}
            };
            
            FireTruckStationBuilderDijkstra builder = new FireTruckStationBuilderDijkstra(roadMap);
            (int crossroad, List<List<int>> ways) = builder.SuitableCrossroad();
            
            Console.Out.WriteLine($"Suitable crossroad is number {crossroad}");
            for (int i = 0; i < ways.Count; i++)
            {
                if (ways[i] != null)
                {
                    StringBuilder sb = new StringBuilder("Way to " + i + " : ");
                    foreach (int point in ways[i])
                    {
                        sb.Append($"{point}->");   
                    }

                    sb.Remove(sb.Length - 2, 2);
                    Console.WriteLine(sb.ToString());
                }
            }
        }
    }
}