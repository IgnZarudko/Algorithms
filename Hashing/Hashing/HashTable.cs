using System;
using System.Net.Sockets;

namespace Hashing
{
    public class HashTable
    {
        public Node[] ArrayOfNodes { get; }

        private readonly ICollisionResolver _collisionResolver;
        private readonly HashCalculator _hashCalculator;
        
        public HashTable(ICollisionResolver collisionResolver, int tableSize = 255, double A = 0.618033)
        {
            _collisionResolver = collisionResolver;
            ArrayOfNodes = new Node[tableSize];
            _hashCalculator = new HashCalculator(A);
        }

        public bool Add(int key, int value)
        {
            Node nodeToAdd = new Node(key, value);
            
            // return OverflowChain.Add(_hashCalculator, ArrayOfNodes, nodeToAdd);
            return _collisionResolver.Add(_hashCalculator, ArrayOfNodes, nodeToAdd);
            // return DoubleHashing.Add(_hashCalculator, ArrayOfNodes, nodeToAdd);
        }

        public int? Get(int key)
        {
            return _collisionResolver.Get(_hashCalculator, ArrayOfNodes, key);
        }
    }
}