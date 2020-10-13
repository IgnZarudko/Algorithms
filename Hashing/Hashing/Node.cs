namespace Hashing
{
    public class Node
    {
        public int Value { get; set; }
        public int Key { get; set; }
        public Node Next { get; set; }

        public Node(int key, int value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }
}