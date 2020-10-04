
using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            
            binaryTree.Add(4);
            binaryTree.Add(2);
            binaryTree.Add(5);
            binaryTree.Add(1);
            binaryTree.Add(3);
            binaryTree.Add(7);
            binaryTree.Add(6);
            binaryTree.Add(8);

            binaryTree.PrintTree();

            binaryTree.Remove(4);
            
            Console.WriteLine();
            
            binaryTree.PrintTree();
            
            
        }
    }
}