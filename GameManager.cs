namespace BullsAndCows
{
    using BullsAndCows.Interfaces;
    using BullsAndCows.Tools;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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


        private IRenderer renderer;
        private IInputManager inputManager;
        private IRandomGenerator randomGenerator;
        //private BullsAndCowsNumber bullsAndCowsNumber = new BullsAndCowsNumber();
        private IList<BullsAndCowsNumber> bullsAndCowsNumbers;
        private ScoreBoard scoreBoard;
        private List<IPlayer> players;

        // TODO: Should be refactored to use a CurrentUser abstraction not indexex.
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
            this.commandHandler = InitializeCommandHandler();
        }

        public bool IsRunning { get; set; }

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

        // TODO: Think for better name!
        public void HandleUserInput(string playerInput)
        {
            if (BullsAndCowsNumber.IsValidNumber(playerInput))
            {
                HandleGuessNumberCommand(playerInput);
            }
            else
            {
                this.commandHandler.ExecuteCommand(playerInput);
            }
        }

        // TODO: Should be added in the CommandHandle after tefactoring
        // TODO: Refacture and split
        private void HandleGuessNumberCommand(string number)
        {
            if (!BullsAndCowsNumber.IsValidNumber(number))
            {
                renderer.WriteLine(InvalidCommandMessage);
                return;
            }

            BullsAndCowsNumber currentBullsAndCowsNumber = this.bullsAndCowsNumbers[this.currentPlayerIndex];
            Result guessResult = currentBullsAndCowsNumber.TryToGuess(number);

            if (guessResult.Bulls < 4)
            {
                renderer.WriteLine("{0} {1}", WrongNumberMessage, guessResult);
                NextPlayer();
                PlayTurn();
            }
            else
            {

                if (currentBullsAndCowsNumber.Cheats == 0)
                {
                    renderer.Write(NumberGuessedWithoutCheats,
                        currentBullsAndCowsNumber.GuessesCount, currentBullsAndCowsNumber.GuessesCount == 1 ? "attempt" : "attempts");

                    scoreBoard.AddScore(this.players[this.currentPlayerIndex].Name, currentBullsAndCowsNumber.GuessesCount);
                    scoreBoard.SaveToFile();
                }
                else
                {
                    renderer.WriteLine(
                        NumberGuessedWithCheats,
                        currentBullsAndCowsNumber.GuessesCount,
                        currentBullsAndCowsNumber.GuessesCount == 1 ? "attempt" : "attempts",
                        currentBullsAndCowsNumber.Cheats,
                        currentBullsAndCowsNumber.Cheats == 1 ? "cheat" : "cheats");
                }

                renderer.Write(scoreBoard);
                renderer.WriteLine();
                renderer.WriteLine(WelcomeMessage);
                currentBullsAndCowsNumber = new BullsAndCowsNumber();
            }
        }


        private ICommandHandler InitializeCommandHandler()
        {
            var commandHandler = new CommandHandler();

            // using this for ease of use can be more granular e.g multiple different parameters
            commandHandler.AddCommand(new RestartCommand(this));
            commandHandler.AddCommand(new ExitCommand(this));
            commandHandler.AddCommand(new HelpCommand(this));
            commandHandler.AddCommand(new TopCommand(this));

            return commandHandler;
        }

        private void SavePlayerScore()
        {

        }

        internal void addPlayer(IPlayer player)
        {
            // TODO: IPlayer validation

            this.players.Add(player);
            this.bullsAndCowsNumbers.Add(new BullsAndCowsNumber());
        }

        public void StartNewGame() {
            for (int i = 0; i < this.players.Count; i++)
            {
                this.bullsAndCowsNumbers[i] = new BullsAndCowsNumber();
            }
        }

        public void NextPlayer()
        {
            // switch the player
            this.currentPlayerIndex = (this.currentPlayerIndex + 1) % this.players.Count;
        }

        public void PlayTurn()
        {
            IPlayer currentPlayer = GetCurrentPlayer();
            // TODO: Needs refactoring
            renderer.Write("{0}, enter your guess or command: ", this.players[this.currentPlayerIndex].Name); 
            //in the previous line add a placefolder and this.bullsAndCowsNumbers[this.currentPlayerIndex] to see the number;
            string currentPlayerInput = currentPlayer.GetInput();
            this.HandleUserInput(currentPlayerInput);

        }

        private IPlayer GetCurrentPlayer()
        {
            // TODO: return something or exception??
            if (this.players.Count == 0)
            {
                throw new ArgumentException("There are no active players!");
            }

            IPlayer currentPlayer = players[this.currentPlayerIndex];
            return currentPlayer;
        }
    }
}
