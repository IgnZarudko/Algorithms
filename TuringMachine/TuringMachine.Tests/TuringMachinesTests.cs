using NUnit.Framework;
using TuringMachine.Garage;

namespace TuringMachine.Tests
{
    public class Tests
    {
        [TestCase("###|||||||##################", "||||||||||||||")]
        [TestCase("|||###########", "||||||")]
        public void MultiplierTest(string inputTape, string outputTape)
        {
            MultiplierByTwo multiplierByTwo = new MultiplierByTwo();

            string output = new string(multiplierByTwo.Evaluate(inputTape.ToCharArray()));

            Assert.IsNotNull(output, "output is null");

            Assert.AreEqual(outputTape, output.Replace("#", ""), "Value on tape is not correct");
        }

        [TestCase("###|||||||###", "||||||")]
        [TestCase("|||###########", "||")]
        public void SubtractorTest(string inputTape, string outputTape)
        {
            SubtractorByOne subtractorByOne = new SubtractorByOne();

            string output = new string(subtractorByOne.Evaluate(inputTape.ToCharArray()));

            Assert.IsNotNull(output, "output is null");

            Assert.AreEqual(outputTape, output.Replace("#", ""), "Value on tape is not correct");
        }


}
}