namespace Hashing
{
    public class HashCalculator
    {
        private double A;

        public HashCalculator(double a)
        {
            A = a;
        }
        
        public int HashFunction(int tableSize, int key)
        {
            return (int)(tableSize * (key * A % 1));
        }

        private int DivisionHashFunction(int tableSize, int key)
        {
            return key % tableSize;
        }

        public int DoubleHashFunction(int tableSize, int key, int iteration = 1)
        {
            return (int)((HashFunction(tableSize, key) + iteration * DivisionHashFunction(tableSize, key)) % tableSize);
        }
    }
}