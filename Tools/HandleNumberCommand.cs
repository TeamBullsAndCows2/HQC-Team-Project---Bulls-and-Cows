namespace BullsAndCows.Tools
{
    using System;

    /// <summary>
    /// Handles user input command when user inputs a valid number.
    /// </summary>
    class HandleNumberCommand : Command
    {
        private const string name = "handleNumberInput";
        private GameManager gameManager;
        private string number;

        public HandleNumberCommand(GameManager gameManager)
            : base(name)
        {
            this.gameManager = gameManager;
        }

        public override void Execute()
        {
            this.number = gameManager.GetCurrentPlayerInput();
            BullsAndCowsNumber currentBullsAndCowsNumber = gameManager.BullsAndCowsNumbers[gameManager.CurrentPlayerIndex];
            Result guessResult = currentBullsAndCowsNumber.TryToGuess(number);

            if (guessResult.Bulls < 4)
            {
                gameManager.Renderer.WriteLine("{0} {1}", GameManager.WrongNumberMessage, guessResult);
                gameManager.NextPlayer();
                gameManager.PlayTurn();
            }
            else
            {
                if (currentBullsAndCowsNumber.Cheats == 0)
                {
                    gameManager.Renderer.Write(
                        GameManager.NumberGuessedWithoutCheats,
                        currentBullsAndCowsNumber.GuessesCount,
                        currentBullsAndCowsNumber.GuessesCount == 1 ? "attempt" : "attempts");

                    gameManager.ScoreBoard.AddScore(gameManager.Players[gameManager.CurrentPlayerIndex].Name, currentBullsAndCowsNumber.GuessesCount);
                    gameManager.ScoreBoard.SaveToFile();
                }
                else
                {
                    gameManager.Renderer.WriteLine(
                        GameManager.NumberGuessedWithCheats,
                        currentBullsAndCowsNumber.GuessesCount,
                        currentBullsAndCowsNumber.GuessesCount == 1 ? "attempt" : "attempts",
                        currentBullsAndCowsNumber.Cheats,
                        currentBullsAndCowsNumber.Cheats == 1 ? "cheat" : "cheats");
                }

                gameManager.Renderer.Write(gameManager.ScoreBoard);
                gameManager.Renderer.WriteLine();
                gameManager.Renderer.WriteLine(GameManager.WelcomeMessage);
                currentBullsAndCowsNumber = new BullsAndCowsNumber();
            }
        }
    }
}
