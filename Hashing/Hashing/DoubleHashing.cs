namespace Hashing
{
    public class DoubleHashing : ICollisionResolver
    {
        public bool Add(HashCalculator hashCalculator, Node[] arrayOfNodes, Node nodeToAdd)
        {
            int hash = hashCalculator.DoubleHashFunction(arrayOfNodes.Length, nodeToAdd.Key);
            int index = hash;
            for(int iteration = 1; arrayOfNodes[index] != null; iteration++)
            {
                if (index == hash && iteration != 1)
                {
                    return false;
                }
                if (arrayOfNodes[index] != null)
                {
                    break;
                }
                index = hashCalculator.DoubleHashFunction(arrayOfNodes.Length, nodeToAdd.Key, iteration);
            }

            arrayOfNodes[index] = nodeToAdd;
            return true;
        }
        
        public int? Get(HashCalculator hashCalculator, Node[] arrayOfNodes, int key)
        {
            int hash = hashCalculator.HashFunction(arrayOfNodes.Length, key);
            int index = hash;
         
            for (int iteration = 1; arrayOfNodes[index] != null; iteration++)
            {
                if (index == hash && iteration != 1)
                {
                    break;
                }
                if (arrayOfNodes[index].Key == key)
                {
                    return arrayOfNodes[index].Value;
                }
                index = hashCalculator.DoubleHashFunction(arrayOfNodes.Length, key, iteration);
            }
            return null;
        }
    }
}