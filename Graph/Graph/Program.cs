using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            // DemoGraphWithComponents();
            // EulerDemo();
            BipartiteDemo();
        }

        private static void DemoGraphWithComponents()
        {
            Console.Out.WriteLine("Demo with connectivity components:");

            int[][] vertexesWithComponents =
            {
                new[] {1, 2},
                new[] {0, 2},
                new[] {0, 1, 3},
                new[] {2, 4, 5},
                new[] {3},
                new[] {3},
                new[] {7, 8},
                new[] {6},
                new[] {6, 9},
                new[] {8},
                new int[0]
            };
            
            List<List<int>> graphWithComponentsList = new List<List<int>>();

            foreach (int[] vertex in vertexesWithComponents)
            {
                graphWithComponentsList.Add(new List<int>(vertex));
            }

            Graph graphWithComponents = new Graph(graphWithComponentsList);
            
            PrintConnectivityComponents(graphWithComponents.ConnectivityComponents);
            
            PrintEulerInfo(graphWithComponents);

            PrintIsGraphBipartite(graphWithComponents);
        }

        private static void EulerDemo()
        {
            Console.Out.WriteLine("Demo with Euler graph");

            int[][] vertexesWithEulerCycle =
            {
                new []{1, 3},
                new []{0, 2, 3, 4},
                new []{1, 4},
                new []{0, 1, 4, 5},
                new []{1, 2, 3, 6},
                new []{3, 6},
                new []{4, 5},
            };
            
            List<List<int>> eulerGraphList = new List<List<int>>();

            foreach (int[] vertex in vertexesWithEulerCycle)
            {
                eulerGraphList.Add(new List<int>(vertex));
            }
            
            Graph eulerGraph = new Graph(eulerGraphList);
            
            PrintConnectivityComponents(eulerGraph.ConnectivityComponents);
            
            PrintEulerInfo(eulerGraph);

            PrintIsGraphBipartite(eulerGraph);
        }

        private static void BipartiteDemo()
        {
            Console.Out.WriteLine("Demo with bipartite graph");

            int[][] vertexesOfBipartiteGraph =
            {
                new[] {6, 9},
                new[] {5, 8},
                new[] {5, 7},
                new[] {8, 9},
                new[] {6, 9},
                new[] {1, 2},
                new[] {0, 4},
                new[] {2},
                new[] {1, 3},
                new[] {0, 3, 4}
            };
            
            List<List<int>> bipartiteGraphList = new List<List<int>>();

            foreach (int[] vertex in vertexesOfBipartiteGraph)
            {
                bipartiteGraphList.Add(new List<int>(vertex));
            }
            
            Graph bipartiteGraph = new Graph(bipartiteGraphList);
            
            PrintConnectivityComponents(bipartiteGraph.ConnectivityComponents);
            
            PrintEulerInfo(bipartiteGraph);

            PrintIsGraphBipartite(bipartiteGraph);
        }
        
        private static void PrintConnectivityComponents(List<List<int>> connectivityComponents)
        {
            Console.WriteLine("===========");
            Console.WriteLine($"Connectivity Components. Total Amount is {connectivityComponents.Count}");

            for (int i = 0; i < connectivityComponents.Count; i++)
            {
                StringBuilder sb = new StringBuilder("");

                sb.Append($"Component {i} - {{ ");
                foreach (int currentVertex in connectivityComponents[i])
                    sb.Append($"{currentVertex}, ");

                sb.Remove(sb.Length - 2, 1);
                sb.Append("}");
                Console.WriteLine(sb.ToString());
            }
            Console.WriteLine("===========");
        }

        private static void PrintEulerInfo(Graph graph)
        {
            Console.WriteLine("===========");
            if (graph.IsEuler())
            {
                Console.WriteLine("Graph is Euler");
                
                Stack<int> eulerCycle = graph.EulerCycle();
                
                Console.Write("Euler cycle: ");
                while (eulerCycle.Count != 0)
                {
                    Console.Write($"{eulerCycle.Pop()} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Graph is not Euler");
            }
            Console.WriteLine("===========");
        }

        private static void PrintIsGraphBipartite(Graph graph)
        {
            Console.WriteLine("===========");
            (List<int> firstPart, List<int> secondPart) = graph.FindBipartiteParts();
            
            if (firstPart != null && secondPart != null)
            {
                Console.WriteLine("Graph is bipartite");
                
                Console.Write("First part: ");
                foreach (int vertex in firstPart)
                {
                    Console.Write($"{vertex} ");
                }
            
                Console.WriteLine();
            
                Console.Write("Second part: ");
                foreach (int vertex in secondPart)
                {
                    Console.Write($"{vertex} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("This graph is not bipartite");
            }
            
            Console.WriteLine("===========");
        }
        
    }
}