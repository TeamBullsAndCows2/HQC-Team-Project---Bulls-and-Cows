namespace BullsAndCows.Common.Test
{
    using BullsAndCows.Common.Tools;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test class for the RandomGenerator class.
    /// </summary>
    [TestClass]
    public class RandomGeneratorTest
    {
        [TestMethod]
        public void CheckForOnlyOneInstanceTest()
        {
            var fistInstance = RandomGenerator.Instance;
            var secondInstance = RandomGenerator.Instance;

            Assert.AreEqual(fistInstance, secondInstance);
        }

        [TestMethod]
        public void CheckForNumberGenerationTest()
        {
            var generator = RandomGenerator.Instance;
            const int OneNumber = 1;

            Assert.AreEqual(OneNumber, generator.GetValue(1, 1));
        }

        [TestMethod]
        public void CheckForArrayGenerationTest()
        {
            var generator = RandomGenerator.Instance;
            int expectedArrayLength = 4;
            int[] generatedAray = generator.GenerateRandomFourDigitArray();
            Assert.AreEqual(expectedArrayLength, generatedAray.Length);
        }
    }
}
