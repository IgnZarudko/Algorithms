using System;

namespace SpanningTree
{
    public class Edge : IComparable<Edge>
    {
        public int Vertice1 { get; }
        public int Vertice2 { get; }
        public int Weight { get; }

        public Edge(int vertice1, int vertice2, int weight)
        {
            Vertice1 = vertice1;
            Vertice2 = vertice2;
            Weight = weight;
        }

        public bool Equals(Edge obj)
        {
            return Weight ==  obj.Weight && ((Vertice1 == obj.Vertice1 && Vertice2 == obj.Vertice2) ||
                                             (Vertice1 == obj.Vertice2 && Vertice2 == obj.Vertice1));
        }

        public int CompareTo(Edge other)
        {
            int difference = Weight - other.Weight;
            if (difference > 0) return 1;
            if (difference < 0) return -1;
            return 0;
        }

        public override string ToString()
        {
            return $"{Vertice1}-{Vertice2} ({Weight})\n";
        }
    }
}