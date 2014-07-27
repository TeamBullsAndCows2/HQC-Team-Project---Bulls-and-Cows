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
            BullsAndCowsNumber number = new BullsAndCowsNumber(new int[] {1, 2, 3, 4});
            
            Assert.AreEqual(number.TryToGuess("1234").Bulls, 4);
            Assert.AreEqual(number.TryToGuess("1234").Cows, 0);
        }
    }
}
