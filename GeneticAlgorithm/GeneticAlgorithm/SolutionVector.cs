using System;

namespace GeneticAlgorithm
{
    public class SolutionVector
    {
        public const int Count = 5;
        
        public int U;
        public int W;
        public int X;
        public int Y;
        public int Z;

        public int this[int i]
        {
            get => i switch
            {
                0 => U,
                1 => W,
                2 => X,
                3 => Y,
                4 => Z,
                _ => throw new IndexOutOfRangeException()
            };
            set
            {
                switch (i)
                {
                    case 0: U = value; break;
                    case 1: W = value; break;
                    case 2: X = value; break;
                    case 3: Y = value; break;
                    case 4: Z = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public SolutionVector(int u, int w, int x, int y, int z) 
        {
            U = u;
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        public SolutionVector Clone() => new SolutionVector(U, W, X, Y, Z);

        public void Copy(SolutionVector vector)
        {
            U = vector.U;
            W = vector.W;
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        public override string ToString()
        {
            return $"({U}, {W}, {X}, {Y}, {Z})";
        }
    }
    
}