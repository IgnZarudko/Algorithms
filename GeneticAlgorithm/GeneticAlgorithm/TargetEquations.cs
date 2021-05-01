using System;

namespace GeneticAlgorithm
{
    public static class TargetEquations
    {
        public static int TargetA(SolutionVector vector)
        {
            var (u, w, x, y, z) = (vector.U, vector.W, vector.X, vector.Y, vector.Z);
            return Math.Abs(-13 + ((w * w) * x * y) + (x * (y * y)) + z + ((u * u) * (w * w) * x * y * z) +
                   (w * x * y * (z * z)));
        }

        public static int TargetB(SolutionVector vector)
        {
            var (u, w, x, y, z) = (vector.U, vector.W, vector.X, vector.Y, vector.Z);
            return Math.Abs(50 + x + y + (u * w * x * y) + ((u * u) * w * x * y) + (u * x * y * (z * z)));
        }
    }
}