using System;

namespace Searches
{
    public static class InterpolationSearch
    {
        public static long Execute(int[] array, int numberToFind, ref int amountOfComparisons)
        {
            long start = 0;
            long end = array.Length - 1;
            
            while (array[start] < numberToFind && numberToFind < array[end] && array[start] != array[end])
            {
                long mid = start + (numberToFind - array[start]) * (end - start) / (array[end] - array[start]);

                if (array[mid] < numberToFind)
                {
                    amountOfComparisons++;
                    start = mid + 1;
                }
                else if (array[mid] > numberToFind)
                {
                    amountOfComparisons += 2; 
                    end = mid - 1;
                }
                else if (array[mid] == numberToFind)
                {
                    amountOfComparisons += 3;
                    Console.WriteLine($"Found at {mid}");
                    return mid;
                }
            }

            if (array[start] == numberToFind)
            {
                amountOfComparisons++;
                Console.WriteLine($"Found at {start}");
                return start;
            }

            if (array[end] == numberToFind)
            {
                amountOfComparisons += 2;
                Console.WriteLine($"Found at {end}");
                return end;
            }

            return -1;
        } 
    }
}