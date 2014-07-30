using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Common.Test
{
    [TestClass]
    public class CheatTest
    {
        [TestMethod]
        public void TestGettingFourCheats()
        {
            int[] number = new int[] { 1, 2, 3, 4 };
            Cheat cheat = new Cheat(number);
            cheat.GetCheat();
            cheat.GetCheat();
            cheat.GetCheat();

            Assert.AreEqual("1234", cheat.GetCheat());
        }

        [TestMethod]
        public void TestFailingGettingFourCheats()
        {
            int[] number = new int[] { 1, 2, 3, 4 };
            Cheat cheat = new Cheat(number);
            cheat.GetCheat();
            cheat.GetCheat();
            cheat.GetCheat();

            Assert.AreNotEqual("1233", cheat.GetCheat());
        }
    }
}
