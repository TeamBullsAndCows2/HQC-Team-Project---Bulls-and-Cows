﻿namespace BullsAndCows.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BullsAndCows.Tools;

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
            var oneNMumber = 1;

            Assert.AreEqual(oneNMumber, generator.GetValue(1, 1));
        }

        [TestMethod]
        public void CheckForNumberInIntervalTest()
        {
            var generator = RandomGenerator.Instance;
            var generatorValue = generator.GetValue(1, 2);
            int[] oneAndTwo = {1, 2};
        }
    }
}