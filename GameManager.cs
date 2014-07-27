namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BullsAndCows.Interfaces;
    using BullsAndCows.Tools;

    /// <summary>
    /// The GameManager class contains the game logic.
    /// </summary>
    public class GameManager
    {
        public const string ScoresFile = "scores.txt";
        public const string WelcomeMessage = "Welcome to “Bulls and Cows” game! Please try to guess my secret 4-digit number.\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.";
        public const string WrongNumberMessage = "Wrong number!";
        public const string InvalidCommandMessage = "Incorrect guess or command!";
        public const string NumberGuessedWithoutCheats = "Congratulations! You guessed the secret number in {0} {1}.\nPlease enter your name for the top scoreboard: ";
        public const string NumberGuessedWithCheats = "Congratulations! You guessed the secret number in {0} {1} and {2} {3}.\nYou are not allowed to enter the top scoreboard.";
        public const string GoodBuyMessage = "Good bye!";

        private const string handleNumberInput = "handleNumberInput";
        private IRenderer renderer;
        private IInputManager inputManager;
        private IRandomGenerator randomGenerator;
        private string currentPlayerInput;
        private IList<BullsAndCowsNumber> bullsAndCowsNumbers;
        private ScoreBoard scoreBoard;
        private List<IPlayer> players;
        private int currentPlayerIndex;
        private ICommandHandler commandHandler;

        public GameManager(IRenderer renderer, IInputManager inputManager)
        {
            this.renderer = renderer;
            this.inputManager = inputManager;
            this.IsRunning = true;
            this.currentPlayerIndex = 0;
            this.scoreBoard = new ScoreBoard(ScoresFile);
            this.players = new List<IPlayer>();
            this.randomGenerator = RandomGenerator.Instance;
            this.bullsAndCowsNumbers = new List<BullsAndCowsNumber>();
            this.commandHandler = this.InitializeCommandHandler();
        }

        public bool IsRunning
        {
            get;
            set;
        }

        public IInputManager InputManager
        {
            get
            {
                return this.inputManager;
            }
        }

        public IRenderer Renderer
        {
            get
            {
                return this.renderer;
            }
        }

        public IList<BullsAndCowsNumber> BullsAndCowsNumbers
        {
            get
            {
                return this.bullsAndCowsNumbers;
            }
        }

        public int CurrentPlayerIndex
        {
            get
            {
                return this.currentPlayerIndex;
            }

            set
            {
                this.currentPlayerIndex = value;
            }
        }

        public ScoreBoard ScoreBoard
        {
            get
            {
                return this.scoreBoard;
            }
        }

        public List<IPlayer> Players
        {
            get
            {
                return this.players;
            }
        }

        /// <summary>
        /// Handles the input of the current player.
        /// </summary>
        public void HandleUserInput(string playerInput)
        {
            if (BullsAndCowsNumber.IsValidNumber(playerInput))
            {
                playerInput = handleNumberInput;
            }

            try
            {
                this.commandHandler.ExecuteCommand(playerInput);
            }
            catch (ArgumentException exception)
            {
                renderer.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// This method switches the current player.
        /// </summary>
        public void NextPlayer()
        {
            this.currentPlayerIndex = (this.currentPlayerIndex + 1) % this.players.Count;
        }

        /// <summary>
        /// Gets the command from the console.
        /// </summary>
        public void PlayTurn()
        {
            IPlayer currentPlayer = this.GetCurrentPlayer();

            // TODO: Needs refactoring
            this.renderer.Write("{0}, enter your guess or command: ", this.players[this.currentPlayerIndex].Name);

            // in the previous line add a placefolder and this.bullsAndCowsNumbers[this.currentPlayerIndex] to see the number;
            this.currentPlayerInput = currentPlayer.GetInput();
            this.HandleUserInput(this.currentPlayerInput);
        }

        public string GetCurrentPlayerInput()
        {
            return this.currentPlayerInput;
        }

        public void StartNewGame()
        {
            for (int i = 0; i < this.players.Count; i++)
            {
                int[] initialNumber = this.randomGenerator.GenerateRandomFourDigitArray();
                this.bullsAndCowsNumbers[i] = new BullsAndCowsNumber(initialNumber);
            }
        }

        internal void AddPlayer(IPlayer player)
        {
            // TODO: IPlayer validation

            this.players.Add(player);
            int[] initialNumber = this.randomGenerator.GenerateRandomFourDigitArray();
            this.bullsAndCowsNumbers.Add(new BullsAndCowsNumber(initialNumber));
        }

        private ICommandHandler InitializeCommandHandler()
        {
            var commandHandler = new CommandHandler();

            commandHandler.AddCommand(new RestartCommand(this));
            commandHandler.AddCommand(new ExitCommand(this));
            commandHandler.AddCommand(new HelpCommand(this));
            commandHandler.AddCommand(new TopCommand(this));
            commandHandler.AddCommand(new HandleNumberCommand(this));

            return commandHandler;
        }

        private void SavePlayerScore()
        {
            throw new NotImplementedException();
        }

        private IPlayer GetCurrentPlayer()
        {
            // TODO: return something or exception??
            if (this.players.Count == 0)
            {
                throw new ArgumentException("There are no active players!");
            }

            IPlayer currentPlayer = this.players[this.currentPlayerIndex];
            return currentPlayer;
        }
    }
}