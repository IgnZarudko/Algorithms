namespace Sorts
{
    public static class MergeSort
    {
        public static void DoMergeSort(int[] array, int start, int end, int k)
        {
            if (end - start + 1 <= k) //3
            {
                InsertionSort.DoInsertionSort(array, start, end); //1
                return; //1
            }
            
            if (start < end) //1
            {
                int border = (start + end) / 2; //4
                DoMergeSort(array, start, border, k); //1
                DoMergeSort(array, border + 1, end, k); //1 
                DoMerge(array, start, border, end); //1
            }
        }

        static void DoMerge(int[] array, int start, int border, int end)
        {
            int[] sortedSubArray = new int[end - start + 1]; //4
            int i = start; //2
            int j = border + 1; //3
            int k = 0; //2
            
            while (i <= border && j <= end) //3
            {
                if (array[i] > array[j]) //3
                {
                    sortedSubArray[k] = array[j]; //3
                    j++; //2
                }
                else
                {
                    sortedSubArray[k] = array[i]; //3
                    i++; //2
                }
                k++; //2
            }

            while (i <= border) //1
            {
                sortedSubArray[k] = array[i]; //3
                k++; //2
                i++; //2
            }
            while (j <= end) //1
            {
                sortedSubArray[k] = array[j]; //3
                k++; //2
                j++; //2
            }

            for (i = start, k = 0; i <= end; i++, k++) //7
            {
                array[i] = sortedSubArray[k]; //3
            }
        }
    }
}