namespace BullsAndCows.Common.Test
{
    using System;
    using System.Collections.Generic;
    using BullsAndCows.Common.Interfaces;
    using BullsAndCows.Common.Tools;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class GameManagerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayTurn_WhenNoPlayersAreAdded()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputManager inputMeneger = new ConsoleInputManager();
            GameManager gm = new GameManager(renderer, inputMeneger);

            // no players added
            gm.PlayTurn();
        }

        [TestMethod]
        public void TestAddPlayer_Adding3PlayersCorrectly()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputManager inputMeneger = new ConsoleInputManager();
            GameManager gm = new GameManager(renderer, inputMeneger);

            IPlayer botPlayer1 = new HumanPlayer("Bot");
            gm.AddPlayer(botPlayer1);
            IPlayer botPlayer2 = new HumanPlayer("Bot2");
            gm.AddPlayer(botPlayer2);
            IPlayer botPlayer3 = new HumanPlayer("Bot3");
            gm.AddPlayer(botPlayer3);

            List<IPlayer> allPlayers = gm.Players;

            Assert.AreEqual(allPlayers.Count, 3);
        }

        [TestMethod]
        public void TestNextPlayer_GetNextPlayerCorrectly()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputManager inputMeneger = new ConsoleInputManager();
            GameManager gm = new GameManager(renderer, inputMeneger);

            IPlayer botPlayer1 = new HumanPlayer("Bot");
            gm.AddPlayer(botPlayer1);
            IPlayer botPlayer2 = new HumanPlayer("Bot2");
            gm.AddPlayer(botPlayer2);
            IPlayer botPlayer3 = new HumanPlayer("Bot3");
            gm.AddPlayer(botPlayer3);

            int curentBot = gm.CurrentPlayerIndex;
            gm.NextPlayer();
            int nextBot = gm.CurrentPlayerIndex;

            Assert.AreEqual(curentBot + 1, nextBot);
        }

        [TestMethod]
        public void TestNextPlayer_GetFirstPlayerCorrectly()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputManager inputMeneger = new ConsoleInputManager();
            GameManager gm = new GameManager(renderer, inputMeneger);

            IPlayer botPlayer1 = new HumanPlayer("Bot");
            gm.AddPlayer(botPlayer1);
            IPlayer botPlayer2 = new HumanPlayer("Bot2");
            gm.AddPlayer(botPlayer2);
            IPlayer botPlayer3 = new HumanPlayer("Bot3");
            gm.AddPlayer(botPlayer3);

            // first bot
            int curentBot = gm.CurrentPlayerIndex;

            // second bot
            gm.NextPlayer();

            // third bot
            gm.NextPlayer();

            // first bot again
            gm.NextPlayer(); 

            Assert.AreEqual(curentBot, 0);
        }
    }
}
