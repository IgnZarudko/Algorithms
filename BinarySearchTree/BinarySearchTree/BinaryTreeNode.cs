using System;

namespace BinarySearchTree
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode(int value)
        {
            Value = value;
            LeftNode = null;
            RightNode = null;
            ParentNode = null;
        }
        
        public BinaryTreeNode LeftNode { get; set; }
        public BinaryTreeNode RightNode { get; set; }
        
        public BinaryTreeNode ParentNode { get; set; }
        public int Value { get; set; }


        public int CompareTo(int other)
        {
            return Value.CompareTo(other);
        }
    }
}