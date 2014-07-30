namespace BullsAndCows.Common.Test
{
    using System;
    using BullsAndCows.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BullsAndCowsNumberTest
    {
        [TestMethod]
        public void TestGuessing()
        {
            BullsAndCowsNumber number = new BullsAndCowsNumber(new int[] { 1, 2, 3, 4 });
            Result result = number.TryToGuess("1234");

            Assert.AreEqual(result.Bulls, 4);
            Assert.AreEqual(result.Cows, 0);
        }

        [TestMethod]
        public void TestGuessingOneCowAndOneBull()
        {
            BullsAndCowsNumber number = new BullsAndCowsNumber(new int[] { 1, 2, 3, 4 });
            Result result = number.TryToGuess("1113");

            Assert.AreEqual(result.Bulls, 1);
            Assert.AreEqual(result.Cows, 1);
        }

        [TestMethod]
        public void TestGuessingOneCowAndOneBullSameDigit()
        {
            BullsAndCowsNumber number = new BullsAndCowsNumber(new int[] { 1, 1, 0, 0 });
            Result result = number.TryToGuess("1221");

            Assert.AreEqual(result.Bulls, 1);
            Assert.AreEqual(result.Cows, 1);
        }

        [TestMethod]
        public void TestGuessingFourEqualDigits()
        {
            BullsAndCowsNumber number = new BullsAndCowsNumber(new int[] { 1, 1, 1, 1 });
            Result result = number.TryToGuess("1000");

            Assert.AreEqual(result.Bulls, 1);
            Assert.AreEqual(result.Cows, 3);
        }

        [TestMethod]
        public void TestFourCows()
        {
            BullsAndCowsNumber number = new BullsAndCowsNumber(new int[] { 1, 2, 3, 4 });
            Result result = number.TryToGuess("4321");

            Assert.AreEqual(result.Bulls, 0);
            Assert.AreEqual(result.Cows, 4);
        }

        [TestMethod]
        public void TestIfAValidNumberIsValid()
        {
            Assert.IsTrue(BullsAndCowsNumber.IsValidNumber("1231"));
        }

        [TestMethod]
        public void TestIfTooLongNumberIsValid()
        {
            Assert.IsFalse(BullsAndCowsNumber.IsValidNumber("12312"));
        }

        [TestMethod]
        public void TestIfTooShortNumberIsValid()
        {
            Assert.IsFalse(BullsAndCowsNumber.IsValidNumber("231"));
        }

        [TestMethod]
        public void TestIfAWordIsValidNumber()
        {
            Assert.IsFalse(BullsAndCowsNumber.IsValidNumber("word"));
        }

        [TestMethod]
        public void TestIfNothingIsValidNumber()
        {
            Assert.IsFalse(BullsAndCowsNumber.IsValidNumber(string.Empty));
        }
    }
}
