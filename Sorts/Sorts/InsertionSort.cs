﻿namespace Sorts
{
    public static class InsertionSort
    {
        // 14n * 10n ~ O(n^2) (для худшего)
        // 18n ~ O(n) (для лучшего)   
        public static void DoInsertionSort(int[] array, int start, int end)
        {
            for (int i = start + 1; i <= end; i++) //6
            {
                int key = array[i]; //3
                int j = i - 1; //3 инициализацию можно не считать 
                while (j > -1 && array[j] > key)//4
                {
                    array[j + 1] = array[j]; //4
                    j--; //2
                }

                array[j + 1] = key;//2
            }
        }
    }
}