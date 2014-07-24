namespace BullsAndCows
{
    using BullsAndCows.Interfaces;
    using BullsAndCows.Tools;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private readonly GameManager manager;

        public Engine()
        {
            manager = new GameManager(new ConsoleRenderer(), new ConsoleInputManager());
        }

        public void Start()
        {
            Console.Write("Enter name for Player 1: ");
            string name = Console.ReadLine();
            IPlayer player = new HumanPlayer(name);
            manager.addPlayer(player);

            Console.Write("Enter name for Player 2: ");
            string name2 = Console.ReadLine();
            IPlayer player2 = new HumanPlayer(name2);
            manager.addPlayer(player2);

            /// Show splash screen
            Console.WriteLine(GameManager.WelcomeMessage);
            Console.WriteLine();

            while (manager.IsRunning)
            {
                manager.PlayTurn();
            }

            // Scores
        }
    }
}
