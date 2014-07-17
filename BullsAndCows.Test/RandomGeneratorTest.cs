namespace BullsAndCows.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BullsAndCows.Tools;

    [TestClass]
    public class RandomGeneratorTest
    {
        [TestMethod]
        public void CheckForOnlyOneInstance()
        {
            var fistInstance = RandomGenerator.Instance;
            var secondInstance = RandomGenerator.Instance;

            Assert.AreEqual(fistInstance, secondInstance);
        }
    }
}
