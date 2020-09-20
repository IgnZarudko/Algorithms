namespace Sorts
{
    public static class InsertionSort
    {
        public static void DoInsertionSort(int[] array, int start, int end)
        {
            end = end == -1 ? array.Length : end;
            
            for (int i = start + 1; i <= end; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j > -1 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }
    }
}