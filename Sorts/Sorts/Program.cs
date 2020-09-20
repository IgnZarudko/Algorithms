using System;

namespace Sorts
{
    static class Program
    {

        delegate void SortMethod(int[] array, int start, int end, int k);
        static void Main(string[] args)
        {
            int[] arrayToSort = CreateRandomArray(10, 1000);
            PrintArray(arrayToSort);
            
            InsertionSort.DoInsertionSort(arrayToSort, 0, arrayToSort.Length - 1);
            QuickSort.DoQuickSort(arrayToSort, 0, arrayToSort.Length - 1, 0);
            MergeSort.DoMergeSort(arrayToSort, 0, arrayToSort.Length - 1, 0);
            
            PrintArray(arrayToSort);


            SortMethod sortMethod = QuickSort.DoQuickSort;
            (int optimalQuickSortK, double timeForQuickSortK) = CountOptimalSizeForHybridSort(100, 10000, 1000, sortMethod);
            Console.WriteLine("For Quick hybrid sort");
            Console.WriteLine($"Optimal k: {optimalQuickSortK}\nIt's time: {timeForQuickSortK}");
            
            
            sortMethod = MergeSort.DoMergeSort;
            (int optimalMergeSortK, double timeForMergeSortK) = CountOptimalSizeForHybridSort(100, 10000, 1000, sortMethod);
            Console.WriteLine("For Merge hybrid sort");
            Console.WriteLine($"Optimal k: {optimalMergeSortK}\nIt's time: {timeForMergeSortK}");
        }

        static (int, double) CountOptimalSizeForHybridSort(int amountOfArrays, int sizeOfArray, int maxValueOfElement, SortMethod sortMethod)
        {
            int k = 1;

            double minimalTime = Double.MaxValue;
            int kForMinimalTime = -1;
            double currentTime = 0.0;
            
            int[][] arrayOfArrays = new int[amountOfArrays][];
            
            for (int i = 0; i < amountOfArrays; i++) 
                arrayOfArrays[i] = CreateRandomArray(sizeOfArray, maxValueOfElement);

            while (k <= 100)
            {
                for (int i = 0; i < amountOfArrays; i++)
                    currentTime += CountTimeForOneSort((int[])arrayOfArrays[i].Clone(), k, sortMethod);
            
                Console.WriteLine($"k = {k}, time = {currentTime / amountOfArrays}");
            
                if (minimalTime > currentTime / amountOfArrays)
                {
                    minimalTime = currentTime / amountOfArrays;
                    kForMinimalTime = k;
                }
                
                currentTime = 0;
                k++;
            }

            return (kForMinimalTime, minimalTime);
        }
        static double CountTimeForOneSort(int[] arrayToSort, int k, SortMethod sortMethod)
        {
            var startTime = (DateTime.Now - new DateTime(2020, 9, 19)).TotalMilliseconds;
            
            sortMethod(arrayToSort, 0, arrayToSort.Length - 1, k);
            
            var endTime = (DateTime.Now - new DateTime(2020, 9, 19)).TotalMilliseconds;
            return endTime - startTime;
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