namespace BullsAndCows
{
    using BullsAndCows.Interfaces;
    using BullsAndCows.Tools;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BullsAndCowsNumber
    {
        IRandomGenerator randomGenerator;
        private char[] cheatNumber;
        private int[] number;

        public BullsAndCowsNumber()
        {
            randomGenerator = RandomGenerator.Instance;
            cheatNumber = new char[4] { 'X', 'X', 'X', 'X' };
            this.number = new int[4];
            this.Cheats = 0;
            this.GuessesCount = 0;
            this.GenerateRandomNumbers();
        }

        public int Cheats
        {
            get;
            private set;
        }

        public int GuessesCount
        {
            get;
            private set;
        }


        // Should be in another class whcih deals with Cheats
        public string GetCheat()
        {
            if (this.Cheats < 4)
            {
                while (true)
                {
                    int randPossition = randomGenerator.GetValue(0, 3);
                    if (cheatNumber[randPossition] == 'X')
                    {
                        switch (randPossition)
                        {
                            case 0: 
                                cheatNumber[randPossition] = (char)(number[0] + '0');
                                break;
                            case 1:
                                cheatNumber[randPossition] = (char)(number[1] + '0');
                                break;
                            case 2:
                                cheatNumber[randPossition] = (char)(number[2] + '0');
                                break;
                            case 3:
                                cheatNumber[randPossition] = (char)(number[3] + '0');
                                break;
                        }
                        break;
                    }
                }

                Cheats++;
            }

            return new String(cheatNumber);
        }

        // Engine?
        public Result TryToGuess(string number)
        {
            if (string.IsNullOrEmpty(number) || number.Trim().Length != 4)
            {
                throw new ArgumentException("Invalid string number");
            }
            int[] numberToGuess = new int[4];
            numberToGuess[0] = number[0] - '0';
            numberToGuess[1] = number[1] - '0';
            numberToGuess[2] = number[2] - '0';
            numberToGuess[3] = number[3] - '0';
            return TryToGuess(numberToGuess);
        }

        private Result TryToGuess(int[] numberToGuess)
        {
            for (int i = 0; i < numberToGuess.Length; i++)
            {
                if (numberToGuess[i] < 0 || numberToGuess[i] > 9)
                {
                    throw new ArgumentException("Invalid digit");
                }
            }

            this.GuessesCount++;
            int bulls = 0;
            int cows = 0;

            for (int i = 0; i < numberToGuess.Length; i++)
            {
                // checks for bulls
                if (this.number[i] == numberToGuess[i])
                {
                    // add a bull
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
                        if (i != j && this.number[i] == numberToGuess[j])
                        {
                            // add a cow and break the loop
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

        // Engine
        private void GenerateRandomNumbers()
        {
            for (int i = 0; i < this.number.Length; i++)
            {
                this.number[i] = randomGenerator.GetValue(0, 9);
            }
        }

        public override string ToString()
        {
            StringBuilder numberStringBuilder = new StringBuilder();

            for (int i = 0; i < this.number.Length; i++)
            {
                numberStringBuilder.Append(this.number[i]);
            }

            return numberStringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            BullsAndCowsNumber objectToCompare = obj as BullsAndCowsNumber;
            if (objectToCompare == null)
            {
                return false;
            }
            else
            {
                return (this.number[0] == objectToCompare.number[0] &&
                        this.number[1] == objectToCompare.number[1] &&
                        this.number[2] == objectToCompare.number[2] &&
                        this.number[3] == objectToCompare.number[3]);
            }
        }

        public override int GetHashCode()
        {
            return this.number[0].GetHashCode() ^
                this.number[1].GetHashCode() ^
                this.number[2].GetHashCode() ^
                this.number[3].GetHashCode();
        }
    }
}
