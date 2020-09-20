namespace Sorts
{
    public static class QuickSort
    {
        public static void DoQuickSort(int[] array, int start, int end, int k)
        {
            if (end - start + 1 <= k) //4
            {
                InsertionSort.DoInsertionSort(array, start, end);//1
                return;//1
            }
            if (start < end) //2
            {
                int border = FindBorder(array, start, end); //3
                DoQuickSort(array, start, border, k); //1
                DoQuickSort(array, border + 1, end, k); //1
            }
        }

        static int FindBorder(int[] array, int start, int end)
        {
            int borderElement = array[(start + end) / 2]; //4
            int i = start - 1; //3
            int j = end + 1; //3
            while (true) //1
            {
                do 
                {
                    i++; //2
                } while (array[i] < borderElement); //2

                do 
                {
                    j--; //2
                } while (array[j] > borderElement); //2

                if (i < j) //2
                    Swap(ref array[i], ref array[j]); //3
                else return j; //2
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int z = a; //2
            a = b; //1
            b = z; //1
        }
    }
}