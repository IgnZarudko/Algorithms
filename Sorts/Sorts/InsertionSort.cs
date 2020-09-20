namespace Sorts
{
    public static class InsertionSort
    {
        public static void DoInsertionSort(int[] array, int start, int end)
        {
            end = end == -1 ? array.Length : end; //3
            
            for (int i = start + 1; i <= end; i++) //6
            {
                int key = array[i]; //3
                int j = i - 1; //3
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