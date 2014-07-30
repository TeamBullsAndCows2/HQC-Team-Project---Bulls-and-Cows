namespace BullsAndCows.Common.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HumanPlayerTest
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestFailedPlayerCreation()
        {
            HumanPlayer player = new HumanPlayer(string.Empty);
        }

        [TestMethod]
        public void TestSuccessPlayerCreation()
        {
            HumanPlayer player = new HumanPlayer("Pesho");
            Assert.AreEqual(player.Name, "Pesho");
        }
    }
}
