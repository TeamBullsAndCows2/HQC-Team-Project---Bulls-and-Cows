namespace BullsAndCows.Interfaces
{
    using System;

    /// <summary>
    /// This is the interface for the random number generator.
    /// </summary>
    interface IRandomGenerator
    {
        int GetValue(int minValue, int maxValue);
    }
}
