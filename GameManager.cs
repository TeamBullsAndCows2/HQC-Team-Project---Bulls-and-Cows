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
        private BullsAndCowsNumber bullsAndCowsNumber = new BullsAndCowsNumber();
        private ScoreBoard scoreBoard = new ScoreBoard(ScoresFile);

        public bool IsRunning { get; private set; }

        public GameManager(IRenderer renderer, IInputManager inputManager)
        {
            this.renderer = renderer;
            this.inputManager = inputManager;
            this.IsRunning = true;
        }

        // TODO: Think for better name!
        public void HandleUserCommand()
        {
            renderer.Write("Enter your guess or command: ");
            string userCommand = inputManager.GetUserInput();
            switch (userCommand)
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
                    HandleDefaultCommand(userCommand);
                    break;
 
            }
        }

        // TODO: Refacture and split
        private void HandleDefaultCommand(string command)
        {
            try
            {
                Result guessResult = bullsAndCowsNumber.TryToGuess(command);

                if (guessResult.Bulls == 4)
                {
                    if (bullsAndCowsNumber.Cheats == 0)
                    {
                        renderer.Write(NumberGuessedWithoutCheats, bullsAndCowsNumber.GuessesCount, bullsAndCowsNumber.GuessesCount == 1 ? "attempt" : "attempts");
                        string name = Console.ReadLine();
                        scoreBoard.AddScore(name, bullsAndCowsNumber.GuessesCount);
                        scoreBoard.SaveToFile(ScoresFile);
                    }
                    else
                    {
                        renderer.WriteLine(
                            NumberGuessedWithCheats,
                            bullsAndCowsNumber.GuessesCount,
                            bullsAndCowsNumber.GuessesCount == 1 ? "attempt" : "attempts",
                            bullsAndCowsNumber.Cheats,
                            bullsAndCowsNumber.Cheats == 1 ? "cheat" : "cheats");
                    }

                    renderer.Write(scoreBoard);
                    renderer.WriteLine();
                    renderer.WriteLine(WelcomeMessage);
                    bullsAndCowsNumber = new BullsAndCowsNumber();
                }
                else
                {
                    renderer.WriteLine("{0} {1}", WrongNumberMessage, guessResult);
                }
            }
            catch (ArgumentException)
            {
                renderer.WriteLine(InvalidCommandMessage);
            }
        }

        private void HandleHelpCommand()
        {
            renderer.WriteLine("The number looks like {0}.", bullsAndCowsNumber.GetCheat());
        }

        private void HandleRestartCommand()
        {
            renderer.WriteLine();
            renderer.WriteLine(WelcomeMessage);
            bullsAndCowsNumber = new BullsAndCowsNumber();
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
    }
}
