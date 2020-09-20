using System;

namespace Sorts
{
    static class Program
    {
        static void Main(string[] args)
        {
            // int[] arrayToSort = CreateRandomArray(10, 1000);
            // PrintArray(arrayToSort);
            //
            // InsertionSort.DoInsertionSort(arrayToSort, 0, arrayToSort.Length - 1);
            // QuickSort.DoQuickSort(arrayToSort, 0, arrayToSort.Length - 1, 0);
            // MergeSort.DoMergeSort(arrayToSort, 0, arrayToSort.Length - 1, 0);
            //
            // PrintArray(arrayToSort);

            
            
            Console.Write(CountOptimalSizeForSwitchToInsertionSort(100, 10000, 1000));
        }

        static void PrintArray(int[] array)
        {
            foreach (var element in array)
            {
                Console.Write(element + " ");
            }
            
            Console.WriteLine();
        }

        static int CountOptimalSizeForSwitchToInsertionSort(int amountOfArrays, int sizeOfArray, int maxValueOfElement)
        {
            int k = 0;

            double minimalTime = Double.MaxValue;
            int kForMinimalTime = -1;
            double currentTime = 0.0;
            
            int[][] arrayOfArrays = new int[amountOfArrays][];
            
            for (int i = 0; i < amountOfArrays; i++) 
                arrayOfArrays[i] = CreateRandomArray(sizeOfArray, maxValueOfElement);

            while (k <= 100)
            {
                for (int i = 0; i < amountOfArrays; i++)
                    currentTime += CountTimeForOneSort((int[])arrayOfArrays[i].Clone(), k);
            
                Console.WriteLine($"k = {k}, time = {currentTime / amountOfArrays}");
            
                if (minimalTime > currentTime / amountOfArrays)
                {
                    minimalTime = currentTime / amountOfArrays;
                    kForMinimalTime = k;
                }
                
                currentTime = 0;
                k++;
            }

            return kForMinimalTime;
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

        static double CountTimeForOneSort(int[] arrayToSort, int k)
        {
            var startTime = (DateTime.Now - new DateTime(2020, 9, 19)).TotalMilliseconds;
            QuickSort.DoQuickSort(arrayToSort, 0, arrayToSort.Length - 1, k);
            // MergeSort.DoMergeSort(arrayToSort, 0, arrayToSort.Length - 1, k);
            // InsertionSort.DoInsertionSort(arrayToSort, 0, arrayToSort.Length - 1);
            var endTime = (DateTime.Now - new DateTime(2020, 9, 19)).TotalMilliseconds;
            return endTime - startTime;
        }
    }
}