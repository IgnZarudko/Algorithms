using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vertexesArray1 = new[] {1, 2};
            int[] vertexesArray2 = new[] {0, 2};
            int[] vertexesArray3 = new[] {0, 1};
            int[] vertexesArray4 = new[] {4, 5};
            int[] vertexesArray5 = new[] {3};
            int[] vertexesArray6 = new[] {3};
            int[] vertexesArray7 = new[] {7, 8};
            int[] vertexesArray8 = new[] {6};
            int[] vertexesArray9 = new[] {6, 9};
            int[] vertexesArray10 = new[] {8};
            int[] vertexesArray11 = new int[0];
            
            List<List<int>> graphList = new List<List<int>>();
            graphList.Add(new List<int>(vertexesArray1));
            graphList.Add(new List<int>(vertexesArray2));
            graphList.Add(new List<int>(vertexesArray3));
            graphList.Add(new List<int>(vertexesArray4));
            graphList.Add(new List<int>(vertexesArray5));
            graphList.Add(new List<int>(vertexesArray6));
            graphList.Add(new List<int>(vertexesArray7));
            graphList.Add(new List<int>(vertexesArray8));
            graphList.Add(new List<int>(vertexesArray9));
            graphList.Add(new List<int>(vertexesArray10));
            graphList.Add(new List<int>(vertexesArray11));
            
            Graph graph = new Graph(graphList);
            
            graph.PrintConnectivityComponents();
        }
    }
}