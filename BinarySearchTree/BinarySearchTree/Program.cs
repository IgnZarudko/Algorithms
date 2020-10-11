
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
            foreach (int number in binaryTree.GetAscendingSequence())
            {
                Console.Write($"{number} ");
            }
            
            Console.WriteLine();
            
            Console.WriteLine("Descending sequence:");
            foreach (int number in binaryTree.GetDescendingSequence())
            {
                Console.Write($"{number} ");
            }
            
            Console.WriteLine();

            int k = 3;
            Console.WriteLine($"k-th minimal element is: {binaryTree.FindKthMinimalElement(3)} (k = {k})");

            binaryTree.BalanceTree();
            
            Console.WriteLine("Balanced tree:");
            
            binaryTree.PrintTree();
        }
    }
}