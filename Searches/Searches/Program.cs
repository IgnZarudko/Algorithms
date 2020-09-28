using System;

namespace Searches
{
    class Program
    {
        public delegate int SearchMethod(int[] array, int numberToFind, ref int amountOfComparisons);
        
        static void Main(string[] args)
        {
            // int[] array = CreateRandomArray(10, 500);
            int[] array = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            PrintArray(array);
            Array.IndexOf(array, 4);
            Console.WriteLine(Array.IndexOf(array, 4));
            // Array.Sort(array);
            int amountOfComparisons = 0;
            Console.WriteLine(BinarySearch.Execute(array, 9, ref amountOfComparisons));
            Console.WriteLine($"Amount of comparisons: {amountOfComparisons}");
        }
        
        static int[] CreateRandomArray(int sizeOfArray, int maxValueOfElement)
        {
            int[] array = new int[sizeOfArray];
            Random random = new Random();
            for (int i = 0; i < sizeOfArray; i++)
            {
                array[i] = random.Next(0, maxValueOfElement);
            }
            return array;
        }
        
        static void PrintArray(int[] array)
        {
            foreach (var element in array)
            {
                Console.Write(element + " ");
            }
            
            Console.WriteLine();
        }
    }
}
