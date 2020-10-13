using System;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ICollisionResolver overflowChain = new OverflowChain();
            ICollisionResolver linearSounding = new LinearSounding();
            ICollisionResolver doubleHashing = new DoubleHashing();

            HashTable hashTableWithOverflowChain = new HashTable(overflowChain, 15, 0.616545);
            HashTable hashTableWithLinearSounding = new HashTable(linearSounding, 45, 0.616545);
            HashTable hashTableWithDoubleHashing = new HashTable(doubleHashing, 45, 0.616545);

            HashTable hashTable = hashTableWithOverflowChain;
            
            for (int i = 0; i < 30; i++)
            {
                hashTable.Add(i, 30 - i);
            }

            Node[] array = hashTable.ArrayOfNodes;

            for (int i = 0; i < array.Length; i++)
            {
                Node current = array[i];
                if (current != null)
                {
                    Console.Write($"{i} => ");
                    do
                    {
                        Console.Write($"{current.Key}-{current.Value} ");
                        current = current.Next;
                    } while (current != null);
                    Console.WriteLine();
                } else Console.WriteLine($"{i} => null");
            }
        }
    }
}