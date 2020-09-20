namespace Sorts
{
    public static class MergeSort
    {
        public static void DoMergeSort(int[] array, int start, int end, int k)
        {
            if (end - start + 1 <= k)
            {
                InsertionSort.DoInsertionSort(array, start, end);
                return;
            }
            
            if (start < end)
            {
                int border = (start + end) / 2;
                DoMergeSort(array, start, border, k);
                DoMergeSort(array, border + 1, end, k);
                DoMerge(array, start, border, end);
            }
        }

        static void DoMerge(int[] array, int start, int border, int end)
        {
            int[] sortedSubArray = new int[end - start + 1];
            int i = start;
            int j = border + 1;
            int k = 0;
            
            while (i <= border && j <= end)
            {
                if (array[i] > array[j])
                {
                    sortedSubArray[k] = array[j];
                    j++;
                }
                else
                {
                    sortedSubArray[k] = array[i];
                    i++;
                }
                k++;
            }

            while (i <= border)
            {
                sortedSubArray[k] = array[i];
                k++;
                i++;
            }
            while (j <= end)
            {
                sortedSubArray[k] = array[j];
                k++;
                j++;
            }

            for (i = start, k = 0; i <= end; i++, k++)
            {
                array[i] = sortedSubArray[k];
            }
        }
    }
}