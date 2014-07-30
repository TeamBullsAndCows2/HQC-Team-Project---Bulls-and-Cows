namespace BullsAndCows.Common.Test
{
    using System;
    using BullsAndCows.Common.Tools;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class MenuTest
    {
        [TestMethod]
        public void TestPressingUpArrow()
        {
            Menu menu = new Menu();
            ConsoleKeyInfo keyPressed = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);

            int result = menu.HandleUserMenuPick(keyPressed);

            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void TestPressingDownArrow()
        {
            Menu menu = new Menu();
            ConsoleKeyInfo keyPressed = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);

            int result = menu.HandleUserMenuPick(keyPressed);

            Assert.AreEqual(result, -1);
        }
        
        [TestMethod]
        public void TestPressingEnter()
        {
            Menu menu = new Menu();
            ConsoleKeyInfo keyPressed = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);

            int result = menu.HandleUserMenuPick(keyPressed);

            Assert.AreEqual(result, menu.GetUserOption());
        }
    }
}
