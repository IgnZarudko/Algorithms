namespace Hashing
{
    public class OverflowChain : ICollisionResolver
    {
        public bool Add(HashCalculator hashCalculator, Node[] arrayOfNodes, Node nodeToAdd)
        {
            int index = hashCalculator.HashFunction(arrayOfNodes.Length, nodeToAdd.Key);
            
            if (arrayOfNodes[index] != null)
            {
                Node currentNode = arrayOfNodes[index];
                while (currentNode.Next != null)
                {
                    if (currentNode.Value == nodeToAdd.Value)
                        return false;
                    currentNode = currentNode.Next;
                }
                currentNode.Next = nodeToAdd;
                return true;
            }
            
            arrayOfNodes[index] = nodeToAdd;

            return true;
        }

        public int? Get(HashCalculator hashCalculator, Node[] arrayOfNodes, int key)
        {
            int index = hashCalculator.HashFunction(arrayOfNodes.Length, key);
            
            Node headOfChain = arrayOfNodes[index];
            
            if (headOfChain == null)
                return null;
            
            while (headOfChain.Key != key && headOfChain.Next != null)
            {
                headOfChain = headOfChain.Next;
            }

            if (headOfChain.Key != key)
                return null;

            return headOfChain.Value;
        }

        
    }
}