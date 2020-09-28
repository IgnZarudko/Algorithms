using NUnit.Framework;

namespace Searches.Tests
{
    [TestFixture]
    public class InterpolationSearchTests
    {
        [TestCase(new [] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 9, 8)]
        [TestCase(new [] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 1, 0)]
        [TestCase(new [] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 4, 3)]
        [TestCase(new [] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 2, 1)]
        [TestCase(new [] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 8, 7)]
        [TestCase(new [] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 10, -1)]
        [TestCase(new [] {1, 2, 3, 5, 6, 7, 8, 9}, 4, -1)]


        
        public void InterpolationSearchTest(int[] array, int numberToFind, int expected)
        {
            int counter = 0;
            Assert.AreEqual(expected, InterpolationSearch.Execute(array, numberToFind, ref counter));
        }
    }
}