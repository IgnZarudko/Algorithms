using System;

namespace BinarySearchTree
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode(int value)
        {
            Value = value;
        }
        
        public BinaryTreeNode LeftNode { get; set; }
        public BinaryTreeNode RightNode { get; set; }
        public int Value { get; private set; }


        public int CompareTo(int other)
        {
            return Value.CompareTo(other);
        }
    }
}