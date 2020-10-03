using System;

namespace Searches
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = CreateRandomArray(100000000, 100000000);
            Array.Sort(array);
            // PrintArray(array);
            Random random = new Random();
            int indexOfElementToFind = random.Next(0, array.Length - 1);
            
            
            Console.WriteLine($"Searching element: {array[indexOfElementToFind]}");
            Console.WriteLine($"Its position: {Array.IndexOf(array, array[indexOfElementToFind])}");

            int amountOfComparisons = 0;
            BinarySearch.Execute(array, array[indexOfElementToFind], ref amountOfComparisons);
            Console.WriteLine($"Amount of comparisons (Binary search): {amountOfComparisons}");
            
            amountOfComparisons = 0;
            InterpolationSearch.Execute(array, array[indexOfElementToFind], ref amountOfComparisons);
            Console.WriteLine($"Amount of comparisons (Interpolation search): {amountOfComparisons}");
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
