namespace BullsAndCows.Common.Test
{
    using System;
    using BullsAndCows.Common.Interfaces;
    using BullsAndCows.Common.Tools;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class ExitCommandTest
    {
        [TestMethod]
        public void TestExecute_IfTerminatesTheGame()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputManager inputMeneger = new ConsoleInputManager();
            GameManager gm = new GameManager(renderer, inputMeneger);
            ExitCommand exitCmd = new ExitCommand(gm);

            exitCmd.Execute();

            Assert.IsFalse(gm.IsRunning);
        }
    }
}
