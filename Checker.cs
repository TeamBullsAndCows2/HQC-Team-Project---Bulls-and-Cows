using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public static class Checker
    {
        public static Result TryToGuess(string numberAsString, ref int guessesCount, int[] number)
        {
            if (string.IsNullOrEmpty(numberAsString) || numberAsString.Trim().Length != 4)
            {
                throw new ArgumentException("Invalid string number");
            }

            int[] numberToGuess = new int[4];
            numberToGuess[0] = numberAsString[0] - '0';
            numberToGuess[1] = numberAsString[1] - '0';
            numberToGuess[2] = numberAsString[2] - '0';
            numberToGuess[3] = numberAsString[3] - '0';
            return TryToGuess(numberToGuess, ref guessesCount, number);
        }

        private static Result TryToGuess(int[] numberToGuess, ref int guessesCount, int[] number)
        {
            for (int i = 0; i < numberToGuess.Length; i++)
            {
                if (numberToGuess[i] < 0 || numberToGuess[i] > 9)
                {
                    throw new ArgumentException("Invalid digit");
                }
            }

            guessesCount++;
            int bulls = 0;
            int cows = 0;

            for (int i = 0; i < numberToGuess.Length; i++)
            {
                // checks for bulls
                if (number[i] == numberToGuess[i])
                {
                    bulls++;
                }
                else
                {
                    // if this digit is not in the right place
                    // loop that digit trough the array of the number's digits in searching for cows
                    for (int j = 0; j < numberToGuess.Length; j++)
                    {
                        // if we are not in the current position and
                        // if the number in the current position is found in the guessed number's array
                        if (i != j && number[i] == numberToGuess[j])
                        {
                            cows++;
                            break;
                        }
                    }
                }
            }

            Result guessResult = new Result();
            guessResult.Bulls = bulls;
            guessResult.Cows = cows;
            return guessResult;
        }
    }
}
