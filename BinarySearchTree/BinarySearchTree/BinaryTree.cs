using System.Collections.Generic;

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

        private static void AddTo(BinaryTreeNode parentNode, BinaryTreeNode insertNode)
        {
            if (insertNode.Value < parentNode.Value)
            {
                if (parentNode.LeftNode == null)
                {
                    parentNode.LeftNode = insertNode;
                    insertNode.ParentNode = parentNode;
                }
                else
                {
                    AddTo(parentNode.LeftNode, insertNode);
                }
            }
            else if (insertNode.Value > parentNode.Value)
            {
                if (parentNode.RightNode == null)
                {
                    parentNode.RightNode = insertNode;
                    insertNode.ParentNode = parentNode;
                }
                else
                {
                    AddTo(parentNode.RightNode, insertNode);
                }
            }
        }

        public bool Contains(int value) => FindByValue(value) != null;

        public bool Remove(int value)
        {
            BinaryTreeNode currentNode = FindByValue(value);

            if (currentNode == null)
            {
                return false;
            }
            
            BinaryTreeNode parentNode = currentNode.ParentNode;
            
            if (currentNode.RightNode == null || currentNode.LeftNode == null)
            {
                BinaryTreeNode nodeToPlace = currentNode.RightNode ?? currentNode.LeftNode;
                if (parentNode == null)
                {
                    _head = nodeToPlace;
                }
                else
                {
                    if (parentNode.LeftNode.Value == currentNode.Value)
                        parentNode.LeftNode = nodeToPlace;
                    else
                        parentNode.RightNode = nodeToPlace;
                }
            }

            if (currentNode.RightNode != null && currentNode.LeftNode != null)
            {
                if (parentNode == null)
                {
                    _head = currentNode.RightNode;
                    AddTo(_head, currentNode.LeftNode);
                }
                else
                {
                    if (parentNode.LeftNode != null && parentNode.LeftNode.Value == currentNode.Value)
                    {
                        parentNode.LeftNode = currentNode.LeftNode;
                        AddTo(parentNode.LeftNode, currentNode.RightNode);
                    }

                    if (parentNode.RightNode != null && parentNode.RightNode.Value == currentNode.Value)
                    {
                        parentNode.RightNode = currentNode.LeftNode;
                        AddTo(parentNode.RightNode, currentNode.RightNode);
                    }
                }
            }
            
            return true;
        }

        private BinaryTreeNode FindByValue(int value, BinaryTreeNode headOfSubtree = null)
        {
            BinaryTreeNode currentNode = headOfSubtree ?? _head;
            
            while (currentNode != null)
            {
                if (currentNode.Value > value)
                {
                    currentNode = currentNode.LeftNode;
                }
                else if (currentNode.Value < value)
                {
                    currentNode = currentNode.RightNode;
                }
                else
                    break;
            }

            return currentNode;
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
            List<int> listOfElements = new List<int>();
            InAscendingOrderWalk(headOfSubtree, listOfElements);
            
            return listOfElements[k - 1];
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

            int middleElement = listOfElements[listOfElements.Count / 2];
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

                if (parentNode.RightNode.RightNode != null)
                {
                    parentNode.RightNode.RightNode.ParentNode = parentNode.RightNode;
                }
            }
        }
    }
}