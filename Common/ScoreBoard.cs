namespace BullsAndCows.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    /// <summary>
    /// The class represents the scoreboard - highscores by players.
    /// </summary>
    public class ScoreBoard
    {
        private const int MaxPlayersToShow = 10;
        private readonly SortedSet<GameScore> scores;
        private string filename;

        public ScoreBoard(string filename)
        {
            this.Filename = filename;
            this.scores = LoadScoresFromFile(this.Filename);
        }

        public string Filename
        {
            get { return this.filename; }
            set { this.filename = value; }
        }

        /// <summary>
        /// Reads the game scores from an external file.
        /// </summary>
        /// <param name="filename">Name of the file, containing the highscores.</param>
        /// <returns>Return the scores.</returns>
        public SortedSet<GameScore> LoadScoresFromFile(string filename)
        {
            var scores = new SortedSet<GameScore>();

            // TODO: messy try catch should be refactored
            try
            {
                using (StreamReader inputStream = new StreamReader(filename))
                {
                    while (!inputStream.EndOfStream)
                    {
                        string scoreString = inputStream.ReadLine();
                        scores.Add(GameScore.GetGameScore(scoreString));
                    }
                }
            }
            catch (IOException)
            {
                // Stop reading
            }
            
            return scores;
        }

        /// <summary>
        /// Adds a player score to the scoreboard
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="guesses">Number of attempts to guess</param>
        public void AddScore(string name, int guesses)
        {
            GameScore newScore = new GameScore(name, guesses);
            this.scores.Add(newScore);
        }

        /// <summary>
        /// Saves game scores in an external file.
        /// </summary>
        public void SaveToFile()
        {
            // TODO: bullshit try catch should be refactored
            try
            {
                using (StreamWriter outputStream = new StreamWriter(this.Filename))
                {
                    foreach (GameScore gameScore in scores)
                    {
                        outputStream.WriteLine(gameScore.FormatGameScore());
                    }
                }
            }
            catch (IOException)
            {
                // Stop writing
            }
        }

        /// <summary>
        /// Displays the scoreboard.
        /// </summary>
        /// <returns>Returns the scoreboard data in the correct format.</returns>
        public override string ToString()
        {
            var lines = this.scores.Take(MaxPlayersToShow);

            if (lines.Count() == 0)
            {
                return "Top scoreboard is empty." + Environment.NewLine;
            }
            else
            {
                StringBuilder scoreBoard = new StringBuilder();
                var index = 1;

                scoreBoard.AppendLine("Scoreboard:");
                foreach (var line in lines)
                {
                    scoreBoard.AppendLine(string.Format("{0}. {1}", index++, line));
                }

                return scoreBoard.ToString();
            }
        }
    }
}
