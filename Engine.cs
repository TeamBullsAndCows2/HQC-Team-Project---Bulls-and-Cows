namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BullsAndCows.Interfaces;
    using BullsAndCows.Tools;
  
    /// <summary>
    /// The Engine runs the game, relying on the GameManager.
    /// </summary>
    public class Engine
    {
        private readonly GameManager manager;

        public Engine()
        {
            this.manager = new GameManager(new ConsoleRenderer(), new ConsoleInputManager());
        }

        public void Start()
        {
            Console.Write("Enter name for Player 1: ");
            string name = Console.ReadLine();
            IPlayer player = new HumanPlayer(name);
            this.manager.addPlayer(player);

            Console.Write("Enter name for Player 2: ");
            string name2 = Console.ReadLine();
            IPlayer player2 = new HumanPlayer(name2);
            this.manager.addPlayer(player2);

            // Show splash screen
            Console.WriteLine(GameManager.WelcomeMessage);
            Console.WriteLine();

            while (this.manager.IsRunning)
            {
                this.manager.PlayTurn();
            }

            // Scores
        }
    }
}
