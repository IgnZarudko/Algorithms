using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearchTree
{
    public class BinaryTree
    {
        private BinaryTreeNode _head;
        public int Count { get; private set; }

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

            Count++;
        }

        private void AddTo(BinaryTreeNode node, BinaryTreeNode valueNode)
        {
            if (valueNode.Value.CompareTo(node.Value) < 0)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = valueNode;
                    valueNode.ParentNode = node;
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
                    valueNode.ParentNode = node;
                }
                else
                {
                    AddTo(node.RightNode, valueNode);
                }
            }
        }

        public bool Contains(int value) => FindByValue(value) != null;

        public bool Remove(int value)
        {
            BinaryTreeNode current = FindByValue(value);

            if (current == null)
            {
                return false;
            }
            
            BinaryTreeNode parent = current.ParentNode;
            
            // BinaryTreeNode parent = current.ParentNode;

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

            Count--;
            return true;
        }

        private BinaryTreeNode FindByValue(int value, BinaryTreeNode headOfSubtree = null)
        {
            BinaryTreeNode current = headOfSubtree ?? _head;
            
            while (current != null)
            {
                int result = current.CompareTo(value);

                if (result > 0)
                {
                    current = current.LeftNode;
                }
                else if (result < 0)
                {
                    current = current.RightNode;
                }
                else
                    break;
            }

            return current;
        }
        
        public void PrintTree()
        {
            TreePrinter.PrintNode(_head);
        }

        public List<int> GetAscendingSequence()
        {
            List<int> ascendingList = new List<int>();
            InAscendingOrderWalk(_head, ascendingList);
            return ascendingList;
        }

        public List<int> GetDescendingSequence()
        {
            List<int> descendingList = new List<int>();
            InDescendingOrderWalk(_head, descendingList);
            return descendingList;
        }

        private void InAscendingOrderWalk(BinaryTreeNode node, List<int> ascendingList)
        {
            if (node != null)
            {
                InAscendingOrderWalk(node.LeftNode, ascendingList);
                ascendingList.Add(node.Value);
                InAscendingOrderWalk(node.RightNode, ascendingList);
            }
        }

        private void InDescendingOrderWalk(BinaryTreeNode node, List<int> descendingList)
        {
            if (node != null)
            {
                InDescendingOrderWalk(node.RightNode, descendingList);
                descendingList.Add(node.Value);
                InDescendingOrderWalk(node.LeftNode, descendingList);
            }
        }

        public int FindKthMinimalElement(int k, BinaryTreeNode headOfSubtree = null)
        {
            headOfSubtree ??= _head;
            
            List<int> elements = new List<int>();
            FindKthMinimalElementRecursively(k, headOfSubtree, elements);
            return elements[^1];
        }

        private void FindKthMinimalElementRecursively(int k, BinaryTreeNode node, List<int> elements)
        {
            if (elements.Count == k)
            {
                return;
            }

            if (node != null)
            {
                FindKthMinimalElementRecursively(k, node.LeftNode, elements);
                elements.Add(node.Value);
                FindKthMinimalElementRecursively(k, node.RightNode, elements);
            }
        }

        public void BalanceTree()
        {
            GetBalancedSubTree(_head);
        }

        private void GetBalancedSubTree(BinaryTreeNode headOfSubtree)
        {
            List<int> listOfElements = new List<int>();
            InAscendingOrderWalk(headOfSubtree, listOfElements);

            if (listOfElements.Count <= 1)
            {
                return;
            }

            int mid = listOfElements.Count / 2;
            int middleElement = FindKthMinimalElement(mid, headOfSubtree);
            BinaryTreeNode nodeToHead = FindByValue(middleElement);

            
            while (nodeToHead.Value != headOfSubtree.Value && nodeToHead.ParentNode != null)
            {
                BinaryTreeNode parentNode = nodeToHead.ParentNode;
                if (parentNode.LeftNode != null && parentNode.LeftNode.Value == nodeToHead.Value)
                {
                    RotateRight(ref parentNode);
                }
                else if (parentNode.RightNode != null && parentNode.RightNode.Value == nodeToHead.Value)
                {
                    RotateLeft(ref parentNode);
                }
                nodeToHead = parentNode;
            }
            
            GetBalancedSubTree(nodeToHead.LeftNode);
            GetBalancedSubTree(nodeToHead.RightNode);
        }

        private void RotateRight(ref BinaryTreeNode parentNode)
        {
            int z = parentNode.Value;
            parentNode.Value = parentNode.LeftNode.Value;
            parentNode.LeftNode.Value = z;
            
            (BinaryTreeNode parentLeft, BinaryTreeNode parentRight) = (parentNode.LeftNode, parentNode.RightNode);
            (BinaryTreeNode nodeLeft, BinaryTreeNode nodeRight) = (parentNode.LeftNode.LeftNode, parentNode.LeftNode.RightNode);
            
            parentNode.RightNode = parentLeft;
            parentNode.LeftNode = nodeLeft;

            parentNode.RightNode.RightNode = parentRight;
            parentNode.RightNode.LeftNode = nodeRight;
            
            SetParentNodes(ref parentNode);
        }

        private void RotateLeft(ref BinaryTreeNode parentNode)
        {
            int z = parentNode.Value;
            parentNode.Value = parentNode.RightNode.Value;
            parentNode.RightNode.Value = z;
            
            (BinaryTreeNode parentLeft, BinaryTreeNode parentRight) = (parentNode.LeftNode, parentNode.RightNode);
            (BinaryTreeNode nodeLeft, BinaryTreeNode nodeRight) = (parentNode.RightNode.LeftNode, parentNode.RightNode.RightNode);

            parentNode.RightNode = nodeRight;
            parentNode.LeftNode = parentRight;

            parentNode.LeftNode.LeftNode = parentLeft;
            parentNode.LeftNode.RightNode = nodeLeft;

            SetParentNodes(ref parentNode);
        }

        private void SetParentNodes(ref BinaryTreeNode parentNode)
        {
            if (parentNode.LeftNode != null)
            {
                parentNode.LeftNode.ParentNode = parentNode;
                if (parentNode.LeftNode.LeftNode != null)
                {
                    parentNode.LeftNode.LeftNode.ParentNode = parentNode.LeftNode;
                }

                if (parentNode.LeftNode.RightNode != null)
                {
                    parentNode.LeftNode.RightNode.ParentNode = parentNode.LeftNode;
                }
            }

            if (parentNode.RightNode != null)
            {
                parentNode.RightNode.ParentNode =  parentNode;
                if (parentNode.RightNode.LeftNode != null)
                {
                    parentNode.RightNode.LeftNode.ParentNode = parentNode.RightNode;
                }

                if (parentNode.RightNode.LeftNode != null)
                {
                    parentNode.RightNode.LeftNode.ParentNode = parentNode.RightNode;
                }
            }
        }
    }
}