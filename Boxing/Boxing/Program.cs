using System;
using System.Collections.Generic;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numbersAmount = 10000;
            var random = new Random();
            
            var numbers = new List<double>();
            for (var i = 0; i < numbersAmount; i++)
            {
                numbers.Add(random.NextDouble() % 1);
            }

            PackAllFits(numbers);
        }

        private static void PackAllFits(List<double> parts)
        {
            Console.WriteLine($"Amount Of Boxes - Next Fit: {Packer.PackNextFit(parts).Count}");
            Console.WriteLine($"Amount Of Boxes - First Fit: {Packer.PackFirstFit(parts).Count}");
            Console.WriteLine($"Amount Of Boxes - Best Fit: {Packer.PackBestFit(parts).Count}");
            Console.WriteLine($"Amount Of Boxes - First Fit Decrease: {Packer.PackFirstFitDecrease(parts).Count}");
        }
    }
}