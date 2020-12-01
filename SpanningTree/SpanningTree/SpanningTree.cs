using System;
using System.Collections.Generic;

namespace SpanningTree
{
    public class SpanningTree
    {
        public static Queue<Edge> SpanningTreePrim(int[][] matrixOfWeights)
        {
            List<Edge> edges = ListOfEdges(matrixOfWeights);
            
            Queue<Edge> spanningTree = new Queue<Edge>();
            HashSet<int> verticesInTree = new HashSet<int>();

            spanningTree.Enqueue(edges[0]);
            verticesInTree.Add(edges[0].Vertice1);
            verticesInTree.Add(edges[0].Vertice2);
            edges.RemoveAt(0);
            
            do
            {
                Edge edgeToRemove = null;
                foreach (var edgeToAdd in edges)
                {
                    if ((verticesInTree.Contains(edgeToAdd.Vertice1) || verticesInTree.Contains(edgeToAdd.Vertice2)) &&
                        !(verticesInTree.Contains(edgeToAdd.Vertice1) && verticesInTree.Contains(edgeToAdd.Vertice2)))
                    {
                        verticesInTree.Add(edgeToAdd.Vertice1);
                        verticesInTree.Add(edgeToAdd.Vertice2);
                        spanningTree.Enqueue(edgeToAdd);
                        edgeToRemove = edgeToAdd;
                        break;
                    }
                }

                if (edgeToRemove != null)
                    edges.Remove(edgeToRemove);
                
            } while (verticesInTree.Count < matrixOfWeights.Length || spanningTree.Count + 1 < matrixOfWeights.Length);


            return spanningTree;
        }
        
        public static Queue<Edge> SpanningTreeKruskal(int[][] matrixOfWeights)
        {
            List<Edge> edges = ListOfEdges(matrixOfWeights);
            
            Queue<Edge> spanningTree = new Queue<Edge>();
            HashSet<int> verticesInTree = new HashSet<int>();

            
            List<List<int>> chains = new List<List<int>>();
            
            spanningTree.Enqueue(edges[0]);
            verticesInTree.Add(edges[0].Vertice1);
            verticesInTree.Add(edges[0].Vertice2);
            edges.RemoveAt(0);
            
            HashSet<int> hashSet = new HashSet<int>();

            do
            {
                Edge edgeToRemove = null;
                foreach (var edgeToAdd in edges)
                {
                    if (!(verticesInTree.Contains(edgeToAdd.Vertice1) && verticesInTree.Contains(edgeToAdd.Vertice2)))
                    {
                        verticesInTree.Add(edgeToAdd.Vertice1);
                        verticesInTree.Add(edgeToAdd.Vertice2);
                        spanningTree.Enqueue(edgeToAdd);
                        edgeToRemove = edgeToAdd;
                        break;
                    }
                }

                if (edgeToRemove != null)
                    edges.Remove(edgeToRemove);
                
            } while (verticesInTree.Count < matrixOfWeights.Length || spanningTree.Count + 1 < matrixOfWeights.Length);


            return spanningTree;
        }

        private static List<Edge> ListOfEdges(int[][] matrixOfWeights)
        {
            List<Edge> edges = new List<Edge>();
            
            for (int i = 0; i < matrixOfWeights.Length - 1; i++)
            {
                for (int j = i + 1; j < matrixOfWeights.Length; j++)
                {
                    edges.Add(new Edge(i, j, matrixOfWeights[i][j]));
                }
            }

            edges.Sort();

            return edges;
        }
    }
}