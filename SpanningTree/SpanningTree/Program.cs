using System;
using System.Collections;
using System.Collections.Generic;

namespace SpanningTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] graphMatrix = new[]
            {
                new[] {0, 4, 1, 3, 1},
                new[] {4, 0, 3, 2, 1},
                new[] {1, 3, 0, 5, 4},
                new[] {3, 2, 5, 0, 0},
                new[] {1, 1, 4, 0, 0}
            };

            Queue<Edge> tree = SpanningTree.SpanningTreePrim(graphMatrix);

            Console.WriteLine("Our tree by Prim:");
            while (tree.Count != 0)
            {
                Console.Write(tree.Dequeue());
            }
            
            
            tree = SpanningTree.SpanningTreeKruskal(graphMatrix);

            Console.WriteLine("Our tree by Kruskal:");
            while (tree.Count != 0)
            {
                Console.Write(tree.Dequeue());
            }
        }
    }
}