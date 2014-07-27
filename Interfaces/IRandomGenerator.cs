namespace BullsAndCows.Common.Interfaces
{
    using System;

    /// <summary>
    /// This is the interface for the random number generator.
    /// </summary>
    interface IRandomGenerator
    {
        /// <summary>
        /// An interface for the creation of a random number.
        /// </summary>
        /// <param name="minValue">The minimal value of the number.</param>
        /// <param name="maxValue">The maximal value of the number.</param>
        /// <returns>Returns a four-digit number as an array.</returns>
        int GetValue(int minValue, int maxValue);

        int[] GenerateRandomFourDigitArray();
    }
}
