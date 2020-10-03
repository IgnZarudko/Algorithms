﻿using System;

namespace Searches
{
    public static class InterpolationSearch
    {
        public static int Execute(int[] array, int numberToFind, ref int amountOfComparisons)
        {
            int start = 0;
            int end = array.Length - 1;

            while (array[start] < numberToFind && numberToFind < array[end])
            {
                int mid = start + (numberToFind - array[start]) * (end - start) / (array[end] - array[start]);
                
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
                    return mid;
                }
            }

            if (array[start] == numberToFind)
            {
                amountOfComparisons++;
                return start;
            }

            if (array[end] == numberToFind)
            {
                amountOfComparisons += 2;
                return end;
            }

            return -1;
        } 
    }
}