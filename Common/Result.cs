namespace BullsAndCows.Common
{
    using System;

    /// <summary>
    /// The class manages the number of bulls and cows to be returned to the player.
    /// </summary>
    public struct Result
    {
        public int Bulls { get; set; }

        public int Cows { get; set; }

        /// <summary>
        /// Tells the player number of bulls and cows from hi input.
        /// </summary>
        /// <returns>Returns message to the player after number input.</returns>
        public override string ToString()
        {
            return string.Format("Bulls: {0}, Cows: {1}", this.Bulls, this.Cows);
        }
    }
}
