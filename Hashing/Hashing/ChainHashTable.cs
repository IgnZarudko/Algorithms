using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Hashing
{
    public class ChainHashTable : IHashTable
    {
        public List<Node>[] ArrayOfNodes { get; }

        private readonly HashCalculator _hashCalculator;

        public ChainHashTable(int tableSize = 255, double A = 0.618033)
        {
            ArrayOfNodes = new List<Node>[tableSize];
            _hashCalculator = new HashCalculator(A);
        }

        public bool Add(int key, int value)
        {
            Node nodeToAdd = new Node(key, value);
            
            if (Get(nodeToAdd.Key) != null)
            {
                return false;
            }
            
            int index = _hashCalculator.HashFunction(ArrayOfNodes.Length, nodeToAdd.Key);

            if (ArrayOfNodes[index] == null)
            {
                ArrayOfNodes[index] = new List<Node>();
                ArrayOfNodes[index].Add(nodeToAdd);
                return true;
            }
            
            ArrayOfNodes[index].Add(nodeToAdd);
            return true;
        }

        public int? Get(int key)
        {
            int index = _hashCalculator.HashFunction(ArrayOfNodes.Length, key);
            
            List<Node> chainToCheck = ArrayOfNodes[index];

            if (chainToCheck == null)
            {
                return null;
            }

            foreach (Node currentNode in chainToCheck)
            {
                if (currentNode.Key == key)
                {
                    return currentNode.Value;
                }
            }

            return null;
        }

        public List<Node>[] GetArrayOfChains()
        {
            return ArrayOfNodes;
        }
    }
}