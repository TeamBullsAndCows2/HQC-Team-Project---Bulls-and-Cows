namespace BullsAndCows
{
    using System;

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
