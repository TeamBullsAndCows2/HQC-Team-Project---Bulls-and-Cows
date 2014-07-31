namespace BullsAndCows.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics.CodeAnalysis;
    using BullsAndCows.Common.Interfaces;
    using BullsAndCows.Common.Tools;
  
    /// <summary>
    /// The Engine runs the game, relying on the GameManager.
    /// </summary> 

    [ExcludeFromCodeCoverage]
    public class Engine
    {
        private readonly GameManager manager;
        private IRenderer renderer = new ConsoleRenderer();
        private IInputManager inputManager = new ConsoleInputManager();

        /// <summary>
        /// Initializes a new instance of Engine class. 
        /// </summary>
        public Engine()
        {
            this.manager = new GameManager(renderer, inputManager);
        }

        /// <summary>
        /// Starts the game, shows startscreen and calls the GameManager.
        /// </summary>
        public void Start()
        {
            Menu menu = new Menu();
            menu.DisplayMenu();
            ConsoleKeyInfo keypress;
            while (true)
            {
                if (this.manager.IsRunning)
                {
                    keypress = Console.ReadKey(true);
                    int option = menu.HandleUserMenuPick(keypress);
                    switch (option)
                    {
                        case 0:
                            this.renderer.Write("Enter player name: ");
                            string playerName = inputManager.GetUserInput();
                            IPlayer player = new HumanPlayer(playerName);

                            this.manager.AddPlayer(player);
                            this.RunGame();
                            break;
                        case 1:
                            this.renderer.Write("Enter the number of players: ");
                            int numberOfPlayers = GetNumberOfPlayers();
                            this.InitializePlayers(numberOfPlayers);
                            this.RunGame();
                            break;

                        case 2:
                            this.manager.HandleUserInput("top");
                            break;
                        case 3:
                            this.manager.HandleUserInput("exit");
                            return;
                        default:
                            break;
                    }
                }
                else
                {
                    break;
                }
            }

            // TODO: Scores
        }
 
        private int GetNumberOfPlayers()
        {
            string userInput = inputManager.GetUserInput();
            int numberOfPlayers = 0;

            bool isValidUserInput = int.TryParse(userInput, out numberOfPlayers);
            if (!isValidUserInput)
            {
                throw new ArgumentException("Invalid users count!");
            }

            return numberOfPlayers;
        }

        private void InitializePlayers(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                renderer.Write(string.Format("Enter name for Player {0}: ", i + 1));
                string name = inputManager.GetUserInput();
                IPlayer player = new HumanPlayer(name);
                this.manager.AddPlayer(player);
            }
        }

        private void RunGame()
        {
            // Show splash screen
            Console.Clear();
            renderer.WriteLine(GameManager.WelcomeMessage);
            renderer.WriteLine();
            while (this.manager.IsRunning)
            {
                this.manager.PlayTurn();
            }
        }
    }
}
