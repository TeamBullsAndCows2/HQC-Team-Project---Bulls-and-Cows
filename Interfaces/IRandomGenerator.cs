namespace BullsAndCows.Interfaces
{
    using System;

    interface IRandomGenerator
    {
        int GetValue(int minValue, int maxValue);
    }
}
