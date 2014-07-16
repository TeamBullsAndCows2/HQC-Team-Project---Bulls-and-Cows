namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BullsAndCowsGame.Interfaces;
    using BullsAndCowsGame.Tools;

    public class GameEngine
    {
        public const string ScoresFile = "scores.txt";
        public const string WelcomeMessage = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.";
        public const string WrongNumberMessage = "Wrong number!";
        public const string InvalidCommandMessage = "Incorrect guess or command!";
        public const string NumberGuessedWithoutCheats = "Congratulations! You guessed the secret number in {0} {1}.\nPlease enter your name for the top scoreboard: ";
        public const string NumberGuessedWithCheats = "Congratulations! You guessed the secret number in {0} {1} and {2} {3}.\nYou are not allowed to enter the top scoreboard.";
        public const string GoodBuyMessage = "Good bye!";

        public static void Main()
        {
            BullsAndCowsNumber bullsAndCowsNumber = new BullsAndCowsNumber();
            ScoreBoard scoreBoard = new ScoreBoard(ScoresFile);
            Console.WriteLine(WelcomeMessage);
            bool isExitSelected = false;

            IRenderer renderer = new ConsoleRenderer(); //Stef: To be done in the GameEngine constructor

            while (true)
            {
                if (isExitSelected)
                {
                    break;
                }

                renderer.Write("Enter your guess or command: ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "exit":
                        renderer.WriteLine(GoodBuyMessage);
                        isExitSelected = true;
                        break;
                    case "top":
                        renderer.Write(scoreBoard);
                        break;
                    case "restart":
                        renderer.WriteLine();
                        renderer.WriteLine(WelcomeMessage);
                        bullsAndCowsNumber = new BullsAndCowsNumber();
                        break;
                    case "help":
                        renderer.WriteLine("The number looks like {0}.", bullsAndCowsNumber.GetCheat());
                        break;
                    default:
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

                        break;
                }
            }

            scoreBoard.SaveToFile(ScoresFile);
        }
    }
}
