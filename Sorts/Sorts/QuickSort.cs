namespace Sorts
{
    public static class QuickSort
    {
        public static void DoQuickSort(int[] array, int start, int end, int k)
        {
            if (end - start + 1 <= k)
            {
                InsertionSort.DoInsertionSort(array, start, end);
                return;
            }
            if (start < end)
            {
                int border = FindBorder(array, start, end);
                DoQuickSort(array, start, border, k);
                DoQuickSort(array, border + 1, end, k);
            }
        }

        static int FindBorder(int[] array, int start, int end)
        {
            int borderElement = array[(start + end) / 2];
            int i = start - 1;
            int j = end + 1;
            while (true)
            {
                do
                {
                    i++;
                } while (array[i] < borderElement);

                do
                {
                    j--;
                } while (array[j] > borderElement);

                if (i < j)
                    Swap(ref array[i], ref array[j]);
                else return j;
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int z = a;
            a = b;
            b = z;
        }
    }
}