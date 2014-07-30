using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Common.Test
{
    [TestClass]
    public class HumanPlayerTest
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestFailedPlayerCreation()
        {
            HumanPlayer player = new HumanPlayer("");
        }

        [TestMethod]
        public void TestSuccessPlayerCreation()
        {
            HumanPlayer player = new HumanPlayer("Pesho");
            Assert.AreEqual(player.Name, "Pesho");
        }
    }
}
