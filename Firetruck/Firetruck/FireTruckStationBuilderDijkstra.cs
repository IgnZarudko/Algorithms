using System;
using System.Collections.Generic;
using System.Linq;

namespace Firetruck
{
    public class FireTruckStationBuilderDijkstra : IFireTruckStationBuilder
    {

        private int[][] SpecialRoadMapLengths { get; }

        private int[][] StartingLengths { get; }

        private List<int>[][] SpecialRoadMapWays { get; }

        public FireTruckStationBuilderDijkstra(int[][] cityRoadMap)
        {
            int amountOfCrossRoads = cityRoadMap.Length;
            SpecialRoadMapLengths = new int[amountOfCrossRoads][];
            StartingLengths = new int[amountOfCrossRoads][];
            SpecialRoadMapWays = new List<int>[amountOfCrossRoads][];

            for (int i = 0; i < amountOfCrossRoads; i++)
            {
                SpecialRoadMapLengths[i] = new int[amountOfCrossRoads];
                StartingLengths[i] = new int[amountOfCrossRoads];
                SpecialRoadMapWays[i] = new List<int>[amountOfCrossRoads];
            }

            for (int i = 0; i < amountOfCrossRoads; i++)
            {
                for (int j = i; j < cityRoadMap[i].Length; j++)
                {
                    SpecialRoadMapLengths[i][j] =
                        cityRoadMap[i][j] < cityRoadMap[j][i] ? cityRoadMap[i][j] : cityRoadMap[j][i];
                    SpecialRoadMapLengths[j][i] = SpecialRoadMapLengths[i][j];
                }
            }

            SpecialRoadMapLengths.CopyTo(StartingLengths, 0);
        }

        public (int crossroadNumber, List<List<int>> ways) SuitableCrossroad()
        {
            RebuildMatrices();

            int indexOfSuitableCrossroad = FindIndexOfSuitableCrossroad();

            return (indexOfSuitableCrossroad, new List<List<int>>(SpecialRoadMapWays[indexOfSuitableCrossroad]));
        }

        private void RebuildMatrices()
        {
            for (int i = 0; i < SpecialRoadMapLengths.Length; i++)
            {
                (SpecialRoadMapLengths[i], SpecialRoadMapWays[i]) = LengthsAndWays(i);
            }
            
            for (int i = 0; i < SpecialRoadMapLengths.Length; i++)
            {
                for (int j = i; j < SpecialRoadMapLengths[i].Length; j++)
                {
                    if (i != j)
                    {
                        if (SpecialRoadMapLengths[i][j] < SpecialRoadMapLengths[j][i])
                        {
                            SpecialRoadMapLengths[j][i] = SpecialRoadMapLengths[i][j];
                        
                            List<int> wayToPlace = new List<int>(SpecialRoadMapWays[i][j]);
                            wayToPlace.Reverse();
                            SpecialRoadMapWays[j][i] = wayToPlace;
                        }
                        else
                        {
                            SpecialRoadMapLengths[i][j] = SpecialRoadMapLengths[j][i];
                        
                            List<int> wayToPlace = new List<int>(SpecialRoadMapWays[j][i]);
                            wayToPlace.Reverse();
                            SpecialRoadMapWays[i][j] = wayToPlace;
                        }
                    }
                }
            }
            
            foreach (var t in SpecialRoadMapLengths)
            {
                for (int j = 0; j < SpecialRoadMapLengths.Length; j++)
                {
                    Console.Write($"{t[j]} ");
                }
                Console.WriteLine();
            }
        }

        private int FindIndexOfSuitableCrossroad()
        {
            int indexOfSuitableRoad = 0;
            int maxLengthOfSuitableRoad = MaxLengthFromCrossroad(0);
            
            int iterationRoad = 1;

            do
            {
                int iterationRoadMax = MaxLengthFromCrossroad(iterationRoad);

                if (iterationRoadMax < maxLengthOfSuitableRoad)
                {
                    indexOfSuitableRoad = iterationRoad;
                    maxLengthOfSuitableRoad = iterationRoadMax;
                }
                else if (iterationRoadMax == maxLengthOfSuitableRoad)
                {
                    int amountOfRoads = SpecialRoadMapLengths.Length;
                    if ((SpecialRoadMapLengths[iterationRoad].Sum() - SpecialRoadMapLengths[iterationRoad][iterationRoad]) / amountOfRoads <
                        (SpecialRoadMapLengths[indexOfSuitableRoad].Sum() - SpecialRoadMapLengths[indexOfSuitableRoad][indexOfSuitableRoad])  / amountOfRoads)
                    {
                        indexOfSuitableRoad = iterationRoad;
                        maxLengthOfSuitableRoad = iterationRoadMax;
                    }  
                }

                iterationRoad++;
            } while (iterationRoad < SpecialRoadMapLengths.Length);
            
            return indexOfSuitableRoad;
        }
        
        private int MaxLengthFromCrossroad(int crossroad)
        {
            int crossroadToItself = SpecialRoadMapLengths[crossroad][crossroad];
            SpecialRoadMapLengths[crossroad][crossroad] = Int32.MinValue;
            int maxLength = SpecialRoadMapLengths[crossroad].Max();
            SpecialRoadMapLengths[crossroad][crossroad] = crossroadToItself;
            return maxLength;
        }
        private (int[] lengths, List<int>[] way) LengthsAndWays(int from)
        {
            bool[] usedVertexes = new bool[SpecialRoadMapLengths.Length];
            int[] distances = new int[SpecialRoadMapLengths.Length];
            int[] previousVertexes = new int[SpecialRoadMapLengths.Length];
            Queue<int> vertexQueue = new Queue<int>();
            
            for (int i = 0; i < SpecialRoadMapLengths.Length; i++)
            {
                usedVertexes[i] = false;
                distances[i] = int.MaxValue;
                previousVertexes[i] = -1;
                vertexQueue.Enqueue(i);
            }

            distances[from] = 0;
            
            while (vertexQueue.Count != 0) {
                int vertex = vertexQueue.Dequeue();
                while (vertexQueue.Count != 0 && (usedVertexes[vertex] || distances[vertex] == int.MaxValue)) {
                    vertex = vertexQueue.Dequeue();
                }

                usedVertexes[vertex] = true;
                for (int i = 0; i < StartingLengths[vertex].Length; i++)
                {
                    int neighbor = i;
                    if (StartingLengths[vertex][neighbor] == int.MaxValue)
                    {
                        continue;
                    }
                    int newDistance = distances[vertex] + StartingLengths[vertex][neighbor];
                    if (!usedVertexes[neighbor] && newDistance < distances[neighbor])
                    {
                        previousVertexes[neighbor] = vertex;
                        distances[neighbor] = newDistance;
                        vertexQueue.Enqueue(neighbor);
                    }
                }
            }
            
            List<int>[] restoredWays = new List<int>[SpecialRoadMapLengths.Length];

            for (int i = 0; i < restoredWays.Length; i++)
            {
                if (i != from)
                {
                    restoredWays[i] = RestoreWay(previousVertexes, i);
                }
            }

            return (distances, restoredWays);
        }

        private List<int> RestoreWay(int[] previousVertexes, int toVertex)
        {
            int currVertex = toVertex;
            List<int> path = new List<int>();
            while(currVertex != -1) {
                path.Add(currVertex);
                currVertex = previousVertexes[currVertex];
            }
            path.Reverse();
            return path;
        }
    }
}