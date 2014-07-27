﻿namespace BullsAndCows.Tools
{
    using System;
    using BullsAndCows.Interfaces;

    /// <summary>
    /// Singleton Random generator class.
    /// </summary>
    public sealed class RandomGenerator : IRandomGenerator
    {
        private static readonly RandomGenerator instance = new RandomGenerator();
        private readonly Random randomGen;

        private RandomGenerator()
        {
            this.randomGen = new Random();
        }

        public static RandomGenerator Instance 
        {
            get
            {
                if (instance == null)
                {
                    return instance;
                }

                return instance;
            }
        }

        public int GetValue(int minValue, int maxValue)
        {
            return this.randomGen.Next(minValue, maxValue + 1);
        }

        public int[] GenerateRandomFourDigitArray()
        {
            int[] number = new int[4];
            number[0] = this.GetValue(1, 9);

            for (int i = 1; i < number.Length; i++)
            {
                number[i] = this.GetValue(0, 9);
            }

            return number;
        }
    }
}
