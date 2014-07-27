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
            const int oneNMumber = 1;

            Assert.AreEqual(oneNMumber, generator.GetValue(1, 1));
        }
    }
}
