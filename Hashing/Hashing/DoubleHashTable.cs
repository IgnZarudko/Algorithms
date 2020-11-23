namespace Hashing
{
    public class DoubleHashTable : IHashTable
    {
        public Node[] ArrayOfNodes { get; }
        private readonly HashCalculator _hashCalculator;
        
        public DoubleHashTable(int tableSize = 255, double A = 0.618033)
        {
            ArrayOfNodes = new Node[tableSize];
            _hashCalculator = new HashCalculator(A);
        }
        
        public bool Add(int key, int value)
        {
            Node nodeToAdd = new Node(key, value);
            
            int hash = _hashCalculator.DoubleHashFunction(ArrayOfNodes.Length, nodeToAdd.Key);
            int index = hash;
            for(int iteration = 1; ArrayOfNodes[index] != null; iteration++)
            {
                if (index == hash && iteration != 1)
                {
                    return false;
                }
                if (ArrayOfNodes[index] != null)
                {
                    break;
                }
                index = _hashCalculator.DoubleHashFunction(ArrayOfNodes.Length, nodeToAdd.Key, iteration);
            }

            ArrayOfNodes[index] = nodeToAdd;
            return true;
        }

        public int? Get(int key)
        {
            int hash = _hashCalculator.DoubleHashFunction(ArrayOfNodes.Length, key);
            int index = hash;
         
            for (int iteration = 1; ArrayOfNodes[index] != null; iteration++)
            {
                if (index == hash && iteration != 1)
                {
                    break;
                }
                if (ArrayOfNodes[index].Key == key)
                {
                    return ArrayOfNodes[index].Value;
                }
                index = _hashCalculator.DoubleHashFunction(ArrayOfNodes.Length, key, iteration);
            }
            return null;
        }
    }
}