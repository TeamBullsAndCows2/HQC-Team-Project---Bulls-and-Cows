using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Common.Test
{
    [TestClass]
    public class CheckerTest
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestArgumentException()
        {
            int guesses = 0;
            Checker.TryToGuess("123", ref guesses, new int[] {1, 2, 3, 4});
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestArgumentExceptionArgumentTooLong()
        {
            int guesses = 0;
            Checker.TryToGuess("12333", ref guesses, new int[] { 1, 2, 3, 4 });
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestArgumentExceptionArgumentNotNumber()
        {
            int guesses = 0;
            Checker.TryToGuess("asdfg", ref guesses, new int[] { 1, 2, 3, 4 });
        }

        [TestMethod]
        public void TestFullyGuessing()
        {
            int guesses = 0;
            Result result = Checker.TryToGuess("1234", ref guesses, new int[] { 1, 2, 3, 4 });

            Assert.AreEqual(guesses, 1);
            Assert.AreEqual(result.Bulls, 4);
            Assert.AreEqual(result.Cows, 0);
        }
    }
}
