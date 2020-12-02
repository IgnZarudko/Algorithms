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

            int[] setOfVertex = new int[matrixOfWeights.Length];

            edges.Sort();
            for (int i = 0; i < setOfVertex.Length; i++) {
                setOfVertex[i] = i;
            }

            foreach (Edge edge in  edges) {
                int vertexA = edge.Vertice1;
                int vertexB = edge.Vertice2;

                if (setOfVertex[vertexA] != setOfVertex[vertexB]) {
                    spanningTree.Enqueue(edge);
                    int newSet = setOfVertex[vertexA];
                    int oldSet = setOfVertex[vertexB];
                    for (int j = 0; j < setOfVertex.Length; j++) {
                        if (setOfVertex[j] == oldSet) {
                            setOfVertex[j] = newSet;
                        }
                    }
                }
            }

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