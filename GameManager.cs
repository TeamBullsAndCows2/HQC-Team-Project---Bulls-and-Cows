namespace BullsAndCows
{
    using BullsAndCows.Interfaces;
    using BullsAndCows.Tools;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GameManager
    {
        public const string ScoresFile = "scores.txt";
        public const string WelcomeMessage = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.";
        public const string WrongNumberMessage = "Wrong number!";
        public const string InvalidCommandMessage = "Incorrect guess or command!";
        public const string NumberGuessedWithoutCheats = "Congratulations! You guessed the secret number in {0} {1}.\nPlease enter your name for the top scoreboard: ";
        public const string NumberGuessedWithCheats = "Congratulations! You guessed the secret number in {0} {1} and {2} {3}.\nYou are not allowed to enter the top scoreboard.";
        public const string GoodBuyMessage = "Good bye!";
        

        private IRenderer renderer;
        private IInputManager inputManager;
        private RandomGenerator randomGenerator = RandomGenerator.Instance;
        //private BullsAndCowsNumber bullsAndCowsNumber = new BullsAndCowsNumber();
        private List<BullsAndCowsNumber> bullsAndCowsNumbers = new List<BullsAndCowsNumber>();
        private ScoreBoard scoreBoard = new ScoreBoard(ScoresFile);
        private List<IPlayer> players = new List<IPlayer>();
        private int currentPlayerIndex;


        public bool IsRunning { get; private set; }

        public GameManager(IRenderer renderer, IInputManager inputManager)
        {
            this.renderer = renderer;
            this.inputManager = inputManager;
            this.IsRunning = true;
            this.currentPlayerIndex = 0;
        }

        // TODO: Think for better name!
        public void HandleUserInput(string playerInput)
        {

            switch (playerInput)
            {
                case "exit":
                    HandleExitCommand();
                    break;
                case "top":
                    HandleTopCommand();
                    break;
                case "restart":
                    HandleRestartCommand();
                    break;
                case "help":
                    HandleHelpCommand();
                    break;
                default:
                    HandleGuessNumberCommand(playerInput);
                    break;

            }
        }

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

                // TODO: NOT HERE!
                this.currentPlayerIndex = (this.currentPlayerIndex + 1) % this.players.Count;
            }
            else
            {

                if (currentBullsAndCowsNumber.Cheats == 0)
                {
                    renderer.Write(NumberGuessedWithoutCheats, currentBullsAndCowsNumber.GuessesCount, currentBullsAndCowsNumber.GuessesCount == 1 ? "attempt" : "attempts");
                    string name = Console.ReadLine();
                    scoreBoard.AddScore(name, currentBullsAndCowsNumber.GuessesCount);
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

        private void SavePlayerScore()
        {

        }

        private void HandleHelpCommand()
        {
            renderer.WriteLine("The number looks like {0}.", this.bullsAndCowsNumbers[this.currentPlayerIndex].GetCheat());
            // TODO: NOT HERE!
            this.currentPlayerIndex = (this.currentPlayerIndex + 1) % this.players.Count;
        }

        private void HandleRestartCommand()
        {
            renderer.WriteLine();
            renderer.WriteLine(WelcomeMessage);
            this.bullsAndCowsNumbers[this.currentPlayerIndex] = new BullsAndCowsNumber();
        }

        private void HandleTopCommand()
        {
            renderer.Write(scoreBoard);
        }

        private void HandleExitCommand()
        {
            this.IsRunning = false;
            renderer.WriteLine(GoodBuyMessage);
        }

        internal void addPlayer(IPlayer player)
        {
            // TODO: IPlayer validation

            this.players.Add(player);
            this.bullsAndCowsNumbers.Add(new BullsAndCowsNumber());
        }

        public void NextTurn()
        {
            IPlayer currentPlayer = GetCurrentPlayer();
            renderer.Write("{0} Enter your guess or command: {1}", this.players[this.currentPlayerIndex].Name, bullsAndCowsNumbers[currentPlayerIndex]);
            string currentPlayerInput = currentPlayer.GetInput();
            this.HandleUserInput(currentPlayerInput);
        }

        private IPlayer GetCurrentPlayer()
        {
            // TODO: If players count == 0 return

            IPlayer currentPlayer = players[this.currentPlayerIndex];
            return currentPlayer;
        }
    }
}
