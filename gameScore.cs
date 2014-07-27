namespace BullsAndCows
{
    using System;

    /// <summary>
    /// The class deals with the players' scores and their rating .
    /// </summary>
    public class GameScore : IComparable
    {
        public string Name { get; private set; }

        public int Guesses { get; private set; }

        /// <summary>
        /// Manages the sores of the players.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Returns the player's name and number of guesses.</returns>
        public static GameScore GetGameScore(string data)
        {
            string[] dataAsStringArray = data.Split(new string[] { "_:::_" }, StringSplitOptions.None);

            if (dataAsStringArray.Length != 2)
            {
                throw new ArgumentException("Data is not in the correct format!");
            }

            string name = dataAsStringArray[0];

            int guesses = 0;

            int.TryParse(dataAsStringArray[1], out guesses);

            return new GameScore(name, guesses);
        }

        public GameScore(string name, int guesses)
        {
            this.Name = name;
            this.Guesses = guesses;
        }

        public override bool Equals(object obj)
        {
            GameScore objectToCompare = obj as GameScore;

            if (objectToCompare == null)
            {
                return false;
            }
            else
            {
                return this.Guesses.Equals(objectToCompare.Guesses) && this.Name.Equals(objectToCompare.Name);
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Guesses.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} --> {1} {2}", this.Name, this.Guesses, this.Guesses == 1 ? "guess" : "guesses");
        }

        // TODO: Curently not used!
        public int CompareTo(object obj)
        {
            GameScore objectToCompare = obj as GameScore;

            if (objectToCompare == null)
            {
                return -1;
            }

            if (this.Guesses.CompareTo(objectToCompare.Guesses) == 0)
            {
                return this.Name.CompareTo(objectToCompare.Name);
            }
            else
            {
                return this.Guesses.CompareTo(objectToCompare.Guesses);
            }
        }

        public string FormatGameScore()
        {
            return string.Format("{0}_:::_{1}", this.Name, this.Guesses);
        }
    }
}
