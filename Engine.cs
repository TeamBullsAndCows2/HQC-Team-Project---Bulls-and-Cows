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
        private IRenderer renderer = new ConsoleRenderer();
        private IInputManager inputManager = new ConsoleInputManager();

        public Engine()
        {
            this.manager = new GameManager(renderer, inputManager);
        }

        /// <summary>
        /// Starts the game, shows startscreen and calls the GameManager.
        /// </summary>
        public void Start()
        {
            renderer.Write("Enter name for Player 1: ");
            string name = inputManager.GetUserInput();
            IPlayer player = new HumanPlayer(name);
            this.manager.AddPlayer(player);

            renderer.Write("Enter name for Player 2: ");
            string name2 = inputManager.GetUserInput();
            IPlayer player2 = new HumanPlayer(name2);
            this.manager.AddPlayer(player2);

            // Show splash screen
            renderer.WriteLine(GameManager.WelcomeMessage);
            renderer.WriteLine();

            while (this.manager.IsRunning)
            {
                this.manager.PlayTurn();
            }

            // Scores
        }
    }
}
