using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Graph
    {
        private List<List<int>> AdjacencyLists { get; set; }
        private List<List<int>> ConnectivityComponents { get; set; }
        private List<bool> UsedVertexes { get; set; }

        public Graph(List<List<int>> adjacencyLists)
        {
            AdjacencyLists = adjacencyLists;
            ConnectivityComponents = new List<List<int>>();
            UsedVertexes = new List<bool>();
            for (int i = 0; i < AdjacencyLists.Count; i++)
            {
                UsedVertexes.Add(false);
            }
            
            FindConnectivityComponents();
        }

        public void FindConnectivityComponents()
        {
            for (int i = 0; i < UsedVertexes.Count; i++)
            {
                if (!UsedVertexes[i])
                {
                    List<int> currentConnectivityComponent = new List<int>();
                    FindOneComponent(i, currentConnectivityComponent);
                    ConnectivityComponents.Add(currentConnectivityComponent);
                }
            }
            
            UsedVertexes.ForEach(vertex => vertex = false);
        }

        private void FindOneComponent(int currentVertex, List<int> currentConnectivityComponent)
        {
            UsedVertexes[currentVertex] = true;
            currentConnectivityComponent.Add(currentVertex);

            for (int i = 0; i < AdjacencyLists[currentVertex].Count; i++)
            {
                int whereDoWeGoNext = AdjacencyLists[currentVertex][i];
                if (!UsedVertexes[whereDoWeGoNext])
                {
                    FindOneComponent(whereDoWeGoNext, currentConnectivityComponent);
                }
            }
        }

        public void PrintConnectivityComponents()
        {
            Console.WriteLine($"Connectivity Components. Total Amount is {ConnectivityComponents.Count}");
            
            for (int i = 0; i < ConnectivityComponents.Count; i++)
            {
                StringBuilder sb = new StringBuilder("");
                
                sb.Append($"Component {i} - {{ ");
                foreach (int currentVertex in ConnectivityComponents[i])
                    sb.Append($"{currentVertex}, ");

                sb.Remove(sb.Length - 2, 1);
                sb.Append("}");
                Console.WriteLine(sb.ToString());
            }
        }

        private void ClearUsedVertices()
        {
            for (int i = 0; i < AdjacencyLists.Count; i++)
            {
                UsedVertexes[i] = false;
            }
        }
    }
}