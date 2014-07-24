﻿namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    /// <summary>
    /// The class represents the scoreboard - highscores by players.
    /// </summary>

    public class ScoreBoard
    {
        private SortedSet<GameScore> scores;
        private const int MaxPlayersToShow = 10;
        private string filename;

        public string Filename
        {
            get { return filename; }
            set { this.filename = value; }
        }

        public ScoreBoard(string filename)
        {
            this.Filename = filename;
            this.scores = LoadScoresFromFile(this.Filename);
        }

        public SortedSet<GameScore> LoadScoresFromFile(string filename)
        {
            var scores = new SortedSet<GameScore>();
            // TODO: bullshit try catch should be refactored
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
