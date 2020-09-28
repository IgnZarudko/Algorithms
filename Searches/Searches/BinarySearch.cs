namespace Searches
{
    public static class BinarySearch
    {
        public static int Execute(int[] array, int numberToFind, ref int amountOfComparisons)
        {
            int indexOfElement = -1;

            int start = 0;
            int end = array.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                
                amountOfComparisons++;
                if (array[mid] == numberToFind) 
                    return mid;
                
                amountOfComparisons++;
                if (array[mid] < numberToFind)
                    start = mid + 1;
                else 
                    end = mid - 1;
            }

            return indexOfElement;
        }
    }
}