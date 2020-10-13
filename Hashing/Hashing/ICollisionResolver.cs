namespace Hashing
{
    public interface ICollisionResolver
    {
        public bool Add(HashCalculator hashCalculator, Node[] arrayOfNodes, Node nodeToAdd);

        public int? Get(HashCalculator hashCalculator, Node[] arrayOfNodes, int key);
    }
}