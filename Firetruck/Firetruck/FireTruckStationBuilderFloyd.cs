using System;
using System.Collections.Generic;
using System.Linq;

namespace Firetruck
{
    public class FireTruckStationBuilderFloyd : IFireTruckStationBuilder
    {
        private int[][] SpecialRoadMapLengths { get; }
        private int[][] SpecialRoadMapWays { get; }

        public FireTruckStationBuilderFloyd(int[][] cityRoadMap)
        {
            int amountOfCrossRoads = cityRoadMap.Length;
            SpecialRoadMapLengths = new int[amountOfCrossRoads][];
            SpecialRoadMapWays = new int[amountOfCrossRoads][];
            
            for (int i = 0; i < amountOfCrossRoads; i++)
            {
                SpecialRoadMapLengths[i] = new int[amountOfCrossRoads];
                SpecialRoadMapWays[i] = new int[amountOfCrossRoads];
                for (int j = 0; j < amountOfCrossRoads; j++)
                {
                    SpecialRoadMapWays[i][j] = j;
                }
            }
            
            for (int i = 0; i < amountOfCrossRoads; i++)
            {
                for (int j = i; j < cityRoadMap[i].Length; j++)
                {
                    SpecialRoadMapLengths[i][j] = cityRoadMap[i][j] < cityRoadMap[j][i] ? cityRoadMap[i][j] : cityRoadMap[j][i];
                    SpecialRoadMapLengths[j][i] = SpecialRoadMapLengths[i][j];
                }
            }   
        }
        

        public (int crossroadNumber, List<List<int>> ways) SuitableCrossroad()
        {
            FloydAlgorithm();
            
            int crossroadNumber = FindIndexOfSuitableCrossroad();

            List<List<int>> ways = RestoreWays(crossroadNumber);

            foreach (var t in SpecialRoadMapLengths)
            {
                for (int j = 0; j < SpecialRoadMapLengths.Length; j++)
                {
                    Console.Write($"{t[j]} ");
                }
                Console.WriteLine();
            }
            
            return (crossroadNumber, ways);
        }
        
        private void FloydAlgorithm()
        {
            int amountOfCrossroads = SpecialRoadMapLengths.Length;

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
                                if (SpecialRoadMapLengths[i][j] > SpecialRoadMapLengths[k][j] + SpecialRoadMapLengths[i][k])
                                {
                                    SpecialRoadMapLengths[i][j] = SpecialRoadMapLengths[k][j] + SpecialRoadMapLengths[i][k];
                                    SpecialRoadMapWays[i][j] = SpecialRoadMapWays[i][k];
                                }
                            }
                        }   
                    }
                }
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

        private List<List<int>> RestoreWays(int crossRoadFrom)
        {
            List<List<int>> restoredWays = new List<List<int>>();

            for (int i = 0; i < SpecialRoadMapLengths.Length; i++)
            {
                restoredWays.Add(i != crossRoadFrom ? RestoreOneWay(crossRoadFrom, i) : null);
            }

            return restoredWays;
        }

        private List<int> RestoreOneWay(int from, int to)
        {
            List<int> restoredWay = new List<int>();
            
            restoredWay.Add(from);
            while (SpecialRoadMapWays[from][to] != to)
            {
                from = SpecialRoadMapWays[from][to];
                restoredWay.Add(from);
            }
            
            restoredWay.Add(to);

            return restoredWay;
        }
    }
}