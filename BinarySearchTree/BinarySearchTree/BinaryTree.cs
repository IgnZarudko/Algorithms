using System;

namespace BinarySearchTree
{
    public class BinaryTree
    {
        private BinaryTreeNode _head;

        public void Add(int value)
        {
            if (_head == null)
            {
                _head = new BinaryTreeNode(value);
            }
            else
            {
                AddTo(_head, new BinaryTreeNode(value));
            }
        }

        private void AddTo(BinaryTreeNode node, BinaryTreeNode valueNode)
        {
            if (valueNode.Value.CompareTo(node.Value) < 0)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = valueNode;
                }
                else
                {
                    AddTo(node.LeftNode, valueNode);
                }
            }
            else if (valueNode.Value.CompareTo(node.Value) > 0)
            {
                if (node.RightNode == null)
                {
                    node.RightNode = valueNode;
                }
                else
                {
                    AddTo(node.RightNode, valueNode);
                }
            }
        }

        public bool Contains(int value)
        {
            BinaryTreeNode parent;
            return FindWithParent(value, out parent) != null;
        }

        public bool Remove(int value)
        {
            BinaryTreeNode parent;
            BinaryTreeNode current = FindWithParent(value, out parent);

            if (current == null)
            {
                return false;
            }
            
            // Есть только один дочерний листок у удаляемого
            if (current.RightNode == null || current.LeftNode == null)
            {
                BinaryTreeNode nodeToPlace = current.RightNode ?? current.LeftNode;
                if (parent == null)
                {
                    _head = nodeToPlace;
                }
                else
                {
                    if (parent.LeftNode.CompareTo(current.Value) == 0)
                        parent.LeftNode = nodeToPlace;
                    else
                        parent.RightNode = nodeToPlace;
                }
            }

            if (current.RightNode != null && current.LeftNode != null)
            {
                if (parent == null)
                {
                    _head = current.RightNode;
                    AddTo(_head, current.LeftNode);
                }
                else
                {
                    //сравниваем с null чтобы сразу обойти сравнение с null в CompareTo
                    if (parent.LeftNode != null && parent.LeftNode.CompareTo(current.Value) == 0)
                    {
                        parent.LeftNode = current.LeftNode;
                        AddTo(parent.LeftNode, current.RightNode);
                    }
                    if (parent.RightNode != null && parent.RightNode.CompareTo(current.Value) == 0)
                    {
                        parent.RightNode = current.LeftNode;
                        AddTo(parent.RightNode, current.RightNode);
                    }
                }
            }
            
            return true;
        }

        private BinaryTreeNode FindWithParent(int value, out BinaryTreeNode parent)
        {
            BinaryTreeNode current = _head;
            parent = null;

            while (current != null)
            {
                int result = current.CompareTo(value);

                if (result > 0)
                {
                    parent = current;
                    current = current.LeftNode;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.RightNode;
                }
                else
                    break;
            }

            return current;
        }


        public void PrintTree()
        {
            // InOrderWalk(_head);
            TreePrinter.PrintNode(_head);
        }

        private void InOrderWalk(BinaryTreeNode node)
        {
            if (node != null)
            {
                InOrderWalk(node.LeftNode);
                Console.Write($"{node.Value} ");
                InOrderWalk(node.RightNode);
            }
        }
    }
}