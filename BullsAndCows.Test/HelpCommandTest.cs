namespace BullsAndCows.Common.Test
{
    using System;
    using BullsAndCows.Common.Interfaces;
    using BullsAndCows.Common.Tools;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HelpCommandTest
    {
        [TestMethod]
        public void TestExecute_IfSwitchesPlayers()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputManager inputMeneger = new ConsoleInputManager();
            GameManager gm = new GameManager(renderer, inputMeneger);
            HelpCommand helpCmd = new HelpCommand(gm);

            IPlayer botPlayer1 = new HumanPlayer("Bot");
            gm.AddPlayer(botPlayer1);
            IPlayer botPlayer2 = new HumanPlayer("Bot2");
            gm.AddPlayer(botPlayer2);

            int beforeExecutionBotIndex = gm.CurrentPlayerIndex;

            // before this like CurrentPlayerIndex should be 0
            helpCmd.Execute();
            int currentBotIndex = gm.CurrentPlayerIndex;

            Assert.AreEqual(beforeExecutionBotIndex, currentBotIndex - 1);
        }
    }
}
