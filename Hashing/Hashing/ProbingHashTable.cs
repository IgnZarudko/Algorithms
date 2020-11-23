namespace Hashing
{
    public class ProbingHashTable : IHashTable
    {
        public Node[] ArrayOfNodes { get; }
        private readonly HashCalculator _hashCalculator;

        public ProbingHashTable(int tableSize = 255, double A = 0.618033)
        {
            ArrayOfNodes = new Node[tableSize];
            _hashCalculator = new HashCalculator(A);
        }
        
        
        public bool Add(int key, int value)
        {
            if (Get(key) != null)
            {
                return false;
            }

            Node nodeToAdd = new Node(key, value);
            
            int index = _hashCalculator.HashFunction(ArrayOfNodes.Length, nodeToAdd.Key);

            if (ArrayOfNodes[index] == null)
            {
                ArrayOfNodes[index] = nodeToAdd;
                return true;
            }

            int indexWhereToAdd = index + 1;

            while (indexWhereToAdd < ArrayOfNodes.Length)
            {
                if (ArrayOfNodes[indexWhereToAdd] != null &&
                    _hashCalculator.HashFunction(ArrayOfNodes.Length, ArrayOfNodes[indexWhereToAdd].Key) > index)
                {
                    return false;
                }
                if (ArrayOfNodes[indexWhereToAdd] == null)
                {
                    ArrayOfNodes[indexWhereToAdd] = nodeToAdd;
                    return true;
                }

                indexWhereToAdd++;
            }

            return false;
        }

        public int? Get(int key)
        {
            int index = _hashCalculator.HashFunction(ArrayOfNodes.Length, key);

            if (ArrayOfNodes[index] == null)
            {
                return null;
            }
            
            if (ArrayOfNodes[index].Key == key)
            {
                return ArrayOfNodes[index].Value;
            }
            
            int indexToCheck = index + 1;
            
            while (indexToCheck < ArrayOfNodes.Length)
            {
                if (ArrayOfNodes[indexToCheck] != null &&
                    _hashCalculator.HashFunction(ArrayOfNodes.Length, ArrayOfNodes[indexToCheck].Key) > index)
                {
                    return null;
                }
                
                if (ArrayOfNodes[indexToCheck] == null)
                {
                    return null;
                }
                
                if (ArrayOfNodes[indexToCheck].Key == key)
                {
                    return ArrayOfNodes[indexToCheck].Value;
                }

                indexToCheck++;
            }

            return null;
        }
    }
}