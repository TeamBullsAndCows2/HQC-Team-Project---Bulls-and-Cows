namespace BullsAndCows.Common.Test
{
    using System;
    using BullsAndCows.Common.Interfaces;
    using BullsAndCows.Common.Tools;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RestartCommandTest
    {
        [TestMethod]
        public void TestExecute_IfRestartCommandExecutesNewGameRight()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputManager inputMeneger = new ConsoleInputManager();
            GameManager gm = new GameManager(renderer, inputMeneger);
            RestartCommand restartCmd = new RestartCommand(gm);

            IPlayer botPlayer1 = new HumanPlayer("Bot");
            gm.AddPlayer(botPlayer1);
            IPlayer botPlayer2 = new HumanPlayer("Bot2");
            gm.AddPlayer(botPlayer2);

            BullsAndCowsNumber firstBotNumber = gm.BullsAndCowsNumbers[0];
            BullsAndCowsNumber secondBotNumber = gm.BullsAndCowsNumbers[1];

            // this will say that the numbers are curently equal
            // Assert.AreEqual(firstBotNumber, gm.BullsAndCowsNumbers[0]);
            // Assert.AreEqual(secondBotNumber, gm.BullsAndCowsNumbers[1]);
            
            // when the cmd is executed new numbers are asigned to the players
            restartCmd.Execute();

            Assert.AreNotEqual(firstBotNumber, gm.BullsAndCowsNumbers[0]);
            Assert.AreNotEqual(secondBotNumber, gm.BullsAndCowsNumbers[1]);
        }
    }
}
