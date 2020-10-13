namespace Hashing
{
    public class LinearSounding : ICollisionResolver
    {
        public bool Add(HashCalculator hashCalculator, Node[] arrayOfNodes, Node nodeToAdd)
        {
            int index = hashCalculator.HashFunction(arrayOfNodes.Length, nodeToAdd.Key);

            if (arrayOfNodes[index] == null)
            {
                arrayOfNodes[index] = nodeToAdd;
                return true;
            }

            int indexWhereToAdd = index + 1;

            while (arrayOfNodes[indexWhereToAdd] != null)
            {
                if (arrayOfNodes[indexWhereToAdd % arrayOfNodes.Length] != null)
                {
                    arrayOfNodes[indexWhereToAdd % arrayOfNodes.Length] = nodeToAdd;
                    return true;
                }

                indexWhereToAdd++;
            }

            return false;
        }

        public int? Get(HashCalculator hashCalculator, Node[] arrayOfNodes, int key)
        {
            int index = hashCalculator.HashFunction(arrayOfNodes.Length, key);

            if (arrayOfNodes[index].Key == key)
                return arrayOfNodes[index].Value;
            
            int indexToCheck = index + 1;
            do
            {
                if (arrayOfNodes[indexToCheck % arrayOfNodes.Length].Key == key)
                    return arrayOfNodes[indexToCheck % arrayOfNodes.Length].Value;
                
                indexToCheck++;
            } while (arrayOfNodes[indexToCheck] != null);

            return null;
        }
    }
}