using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Common.Interfaces;
using BullsAndCows.Common.Tools;

namespace BullsAndCows.Common.Test
{
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
