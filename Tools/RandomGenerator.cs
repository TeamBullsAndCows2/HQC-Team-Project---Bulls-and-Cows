namespace BullsAndCows.Common.Tools
{
    using System;
    using System.Linq;
    using BullsAndCows.Common.Interfaces;
    
    /// <summary>
    /// Singleton Random generator class.
    /// </summary>
    public sealed class RandomGenerator : IRandomGenerator
    {
        private const int UpperBound = 9;
        private static readonly RandomGenerator instance = new RandomGenerator();
        private readonly Random randomGen;
        
        private RandomGenerator()
        {
            this.randomGen = new Random();
        }

        /// <summary>
        /// Gets the only instance of RandomGenerator class.
        /// </summary>
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

        /// <summary>
        /// Returns random value within a range.
        /// </summary>
        /// <param name="minValue">Lower bound of generated numbers</param>
        /// <param name="maxValue">Higher bound of generated numbers</param>
        /// <returns>Generated random number within provided range.</returns>
        public int GetValue(int minValue, int maxValue)
        {
            return this.randomGen.Next(minValue, maxValue + 1);
        }

        /// <summary>
        /// Generate array with four distinct digits
        /// </summary>
        /// <returns>Generated array</returns>
        public int[] GenerateRandomFourDigitArray()
        {
            int[] number = new int[4];
            number[0] = this.GetValue(1, UpperBound);

            for (int i = 1; i < number.Length; i++)
            {
                number[i] = GetDistinctDigit(number, UpperBound);
            }

            return number;
        }
 
        private int GetDistinctDigit(int[] number, int upperBound)
        {
            if (upperBound <= number.Length)
            {
                throw new ArgumentOutOfRangeException("Upper bound must be greater or equal than number array!");
            }

            int distinctDigit = 0;

            bool isDistinctDigit = false;
            while (!isDistinctDigit)
            {
                int generatedDigit = this.GetValue(0, upperBound);
                if (!number.Contains(generatedDigit))
                {
                    distinctDigit = generatedDigit;
                    isDistinctDigit = true;
                }
            }

            return distinctDigit;
        }
    }
}
