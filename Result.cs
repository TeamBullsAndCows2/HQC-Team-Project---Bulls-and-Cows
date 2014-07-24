namespace BullsAndCows
{
    using System;


    /// <summary>
    /// The class manages the number of bulls and cows to be returned to the player.
    /// </summary>
    public struct Result
    {
        public int Bulls { get; set; }

        public int Cows { get; set; }

        public override string ToString()
        {
            return string.Format("Bulls: {0}, Cows: {1}", this.Bulls, this.Cows);
        }
    }
}
