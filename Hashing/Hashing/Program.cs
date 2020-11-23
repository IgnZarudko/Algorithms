using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Hashing
{
    class Program
    {
        public static void Main(string[] args)
        {
            // DemoChainingHashTable();
            // DemoProbingHashTable();
            // DemoDoubleHashTable();

            int amountOfKeyLists = 20;
            int lengthOfSeveralList = 80;
            int rangeOfValues = 1000;
            
            int M = 25;


            List<int>[] keyLists = GenerateKeys(amountOfKeyLists, lengthOfSeveralList, rangeOfValues);


            int counterOfWinsForCustom = 0;
            int counterOfWinsForKnuth = 0;
            
            for (int i = 0; i < amountOfKeyLists; i++)
            {
                ChainHashTable chainHashTableKnuth = new ChainHashTable(M, 0.6180339887);
                ChainHashTable chainHashTableCustom = new ChainHashTable(M, 0.7546565213);

                foreach (List<int> list in keyLists)
                {
                    foreach (int key in list)
                    {
                        chainHashTableKnuth.Add(key, key);
                        chainHashTableCustom.Add(key, key);
                    }

                    var maxKnuth = chainHashTableKnuth.ArrayOfNodes.Max(chainsList => chainsList?.Count);
                    var maxCustom = chainHashTableCustom.ArrayOfNodes.Max(chainsList => chainsList?.Count);
                        
                    Console.WriteLine($"largest chain of knuth - {maxKnuth}");
                    Console.WriteLine($"largest chain of custom - {maxCustom}");
                    Console.WriteLine("------");
                    if (maxCustom <= maxKnuth)
                    {
                        counterOfWinsForCustom++;
                    }
                    else
                    {
                        counterOfWinsForKnuth++;
                    }
                }
            }
            
            Console.WriteLine($"Custom has won {counterOfWinsForCustom} times");
            Console.WriteLine($"Knuth has won {counterOfWinsForKnuth} times");
            Console.WriteLine($"Custom number wins - {counterOfWinsForCustom > counterOfWinsForKnuth}");
        }

        private static List<int>[] GenerateKeys(int amountOfKeyLists, int lengthOfSeveralList, int rangeOfValues)
        {
            List<int>[] keyLists = new List<int>[amountOfKeyLists];

            for (int i = 0; i < amountOfKeyLists; i++)
            {
                keyLists[i] = GenerateListOfKeys(lengthOfSeveralList, rangeOfValues, i);
            }

            return keyLists;
        }

        private static List<int> GenerateListOfKeys(int lengthOfSeveralList, int rangeOfValues, int seed)
        {
            List<int> listOfKeys = new List<int>(0);
            
            Random random = new Random(seed);
            for (int i = 0; i < lengthOfSeveralList; i++)
            {
                listOfKeys.Add(random.Next(1, rangeOfValues));
            }

            return listOfKeys;
        }
        
        private static void DemoChainingHashTable()
        {
            ChainHashTable chainHashTable = new ChainHashTable(15, 0.616545);
            
            for (int i = 0; i < 30; i++)
            {
                chainHashTable.Add(i, 30 - i);
            }

            List<Node>[] array = chainHashTable.ArrayOfNodes;

            for (int i = 0; i < array.Length; i++)
            {
                List<Node> currentChain = array[i];
                if (currentChain != null)
                {
                    Console.Write($"{i} => ");
                    foreach (Node node in currentChain)
                    {
                        Console.Write($"{node.Key}-{node.Value} ");
                    }
                    
                    Console.WriteLine();
                    
                }
                else
                {
                    Console.WriteLine($"{i} => empty");
                }
            }
            
            for (int i = 0; i < 30; i++)
            {
                Console.Write($"{chainHashTable.Get(i)} ");
            }
        }
        
        private static void DemoProbingHashTable()
        {
            ProbingHashTable probingHashTable = new ProbingHashTable(45, 0.616545);
            
            for (int i = 0; i < 30; i++)
            {
                probingHashTable.Add(i, 30 - i);
            }

            Node[] array = probingHashTable.ArrayOfNodes;

            for (int i = 0; i < array.Length; i++)
            {
                Node currentNode = array[i];
                if (currentNode != null)
                {
                    Console.Write($"{i} => {currentNode.Key}-{currentNode.Value}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{i} => empty");
                }
            }
            
            for (int i = 0; i < 30; i++)
            {
                Console.Write($"{probingHashTable.Get(i)} ");
            }
        }

        private static void DemoDoubleHashTable()
        {
            DoubleHashTable doubleHashTable = new DoubleHashTable(45, 0.616545);

            for (int i = 0; i < 30; i++)
            {
                doubleHashTable.Add(i, 30 - i);
            }
            
            Node[] array = doubleHashTable.ArrayOfNodes;
            
            for (int i = 0; i < array.Length; i++)
            {
                Node currentNode = array[i];
                if (currentNode != null)
                {
                    Console.Write($"{i} => {currentNode.Key}-{currentNode.Value}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{i} => empty");
                }
            }
            
            for (int i = 0; i < 30; i++)
            {
                Console.Write($"{doubleHashTable.Get(i)} ");
            }
        }
    }
}