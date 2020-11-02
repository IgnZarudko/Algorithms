
using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();

            int[] numbersToAdd = new[] {1, 2, 9, 6, 7, 4, 10};

            foreach (int number in numbersToAdd)
            {
                binaryTree.Add(number);
            }
            
            Console.WriteLine("Got Tree:");
            binaryTree.PrintTree();

            Console.WriteLine("Ascending sequence:");
            foreach (int number in binaryTree.AscendingSequence())
            {
                Console.Write($"{number} ");
            }
            
            Console.WriteLine();
            
            Console.WriteLine("Descending sequence:");
            foreach (int number in binaryTree.DescendingSequence())
            {
                Console.Write($"{number} ");
            }
            
            Console.WriteLine();

            int k = 5;
            Console.WriteLine($"k-th minimal element is: {binaryTree.FindKthMinimalElement(k).Value} (k = {k})");

            binaryTree.BalanceTree();
            
            Console.WriteLine("Balanced tree:");
            
            binaryTree.PrintTree();
        }
    }
}