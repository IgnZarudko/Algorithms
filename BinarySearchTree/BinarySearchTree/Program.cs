
using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();

            //{ 1, 2, 9, 6, 7, 4, 10 }
            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(9);
            binaryTree.Add(6);
            binaryTree.Add(7);
            binaryTree.Add(4);
            binaryTree.Add(10);
            // binaryTree.Add(24);

            binaryTree.PrintTree();
            
            Console.WriteLine(binaryTree.FindKthMinimalElement(3));
            
            binaryTree.BalanceTree();
            
            binaryTree.PrintTree();
            // int number = binaryTree.FindKthMinimalElement(3);
            // Console.WriteLine(number);
        }
    }
}