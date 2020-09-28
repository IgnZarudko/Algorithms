using NUnit.Framework;

namespace Searches.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 9, 8)]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 1, 0)]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 4, 3)]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 2, 1)]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 8, 7)]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 10, -1)]
        [TestCase(new int[] {1, 2, 3, 5, 6, 7, 8, 9}, 4, -1)]


        
        public void BinarySearchTest(int[] array, int numberToFind, int expected)
        {
            int counter = 0;
            Assert.AreEqual(expected, BinarySearch.Execute(array, numberToFind, ref counter));
        }
    }
}