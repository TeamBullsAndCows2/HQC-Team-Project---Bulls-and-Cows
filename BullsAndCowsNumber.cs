namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BullsAndCowsNumber
    {
        // TODO: Random should be extracted in external class
        Random randomGenerator;
        char[] cheatNumber;

        public BullsAndCowsNumber()
        {
            randomGenerator = new Random();
            cheatNumber = new char[4] { 'X', 'X', 'X', 'X' };
            this.Cheats = 0;
            this.GuessesCount = 0;
            this.GenerateRandomNumbers();
        }

        public int Cheats { get; private set; }

        public int GuessesCount { get; private set; }

        public int FirstDigit { get; private set; }

        public int SecondDigit { get; private set; }

        public int ThirdDigit { get; private set; }

        public int FourthDigit { get; private set; }

        public string GetCheat()
        {
            if (this.Cheats < 4)
            {
                while (true)
                {
                    int randPossition = randomGenerator.Next(0, 4);
                    if (cheatNumber[randPossition] == 'X')
                    {
                        switch (randPossition)
	                    {
                            case 0: 
                                cheatNumber[randPossition] = (char)(FirstDigit + '0'); 
                                break;
                            case 1:
                                cheatNumber[randPossition] = (char)(SecondDigit + '0'); 
                                break;
                            case 2: 
                                cheatNumber[randPossition] = (char)(ThirdDigit + '0'); 
                                break;
                            case 3: 
                                cheatNumber[randPossition] = (char)(FourthDigit + '0'); 
                                break;
	                    }
                        break;
                    }
                }

                Cheats++;
            }

            return new String(cheatNumber);
        }

        public Result TryToGuess(string number)
        {
            if (string.IsNullOrEmpty(number) || number.Trim().Length != 4)
            {
                throw new ArgumentException("Invalid string number");
            }

            return TryToGuess(number[0] - '0', number[1] - '0', number[2] - '0', number[3] - '0');
        }

        private void RaiseExceptionForInvalidDigit(int firstDigit, int secondDigit, int thirdDigit, int fourthDigit)
        {
            if (firstDigit < 0 || firstDigit > 9)
            {
                throw new ArgumentException("Invalid first digit");
            }

            if (secondDigit < 0 || secondDigit > 9)
            {
                throw new ArgumentException("Invalid second digit");
            }

            if (thirdDigit < 0 || thirdDigit > 9)
            {
                throw new ArgumentException("Invalid third digit");
            }

            if (fourthDigit < 0 || fourthDigit > 9)
            {
                throw new ArgumentException("Invalid fourth digit");
            }
        }

        private Result TryToGuess(int firstDigit, int secondDigit, int thirdDigit, int fourthDigit)
        {
            RaiseExceptionForInvalidDigit(firstDigit, secondDigit, thirdDigit, fourthDigit);

            this.GuessesCount++;

            // Quite Long and relevantly stupid algorithm should be refactored
            int bulls = 0;
            bool[] isDigitBullOrCow = {false, false, false, false};
            //bool isFirstDigitBullOrCow = false;

            // checks if firstDigit is a bull:
            if (this.FirstDigit == firstDigit)
            {
                isDigitBullOrCow[0] = true;
                bulls++;
            }

            // checks if secondDigit is a bull:
            if (this.SecondDigit == secondDigit)
            {
                isDigitBullOrCow[1] = true;
                bulls++;
            }

            // checks if thirdDigit is a bull:
            if (this.ThirdDigit == thirdDigit)
            {
                isDigitBullOrCow[2] = true;
                bulls++;
            }

            // checks if fourthDigit is a bull:
            if (this.FourthDigit == fourthDigit)
            {
                isDigitBullOrCow[3] = true;
                bulls++;
            }

            int cows = 0;

            // checks if firstDigit is cow:
            if (!isDigitBullOrCow[1] && firstDigit == SecondDigit)
            {
                isDigitBullOrCow[1] = true;
                cows++;
            }
            else if (!isDigitBullOrCow[2] && firstDigit == ThirdDigit)
            {
                isDigitBullOrCow[2] = true;
                cows++;
            }
            else if (!isDigitBullOrCow[3] && firstDigit == FourthDigit)
            {
                isDigitBullOrCow[3] = true;
                cows++;
            }

            // checks if secondDigit is cow:
            if (!isDigitBullOrCow[0] && secondDigit == FirstDigit)
            {
                isDigitBullOrCow[0] = true;
                cows++;
            }
            else if (!isDigitBullOrCow[2] && secondDigit == ThirdDigit)
            {
                isDigitBullOrCow[2] = true;
                cows++;
            }
            else if (!isDigitBullOrCow[3] && secondDigit == FourthDigit)
            {
                isDigitBullOrCow[3] = true;
                cows++;
            }

            // checks if thirdDigit is cow:
            if (!isDigitBullOrCow[0] && thirdDigit == FirstDigit)
            {
                isDigitBullOrCow[0] = true;
                cows++;
            }
            else if (!isDigitBullOrCow[1] && thirdDigit == SecondDigit)
            {
                isDigitBullOrCow[1] = true;
                cows++;
            }
            else if (!isDigitBullOrCow[3] && thirdDigit == FourthDigit)
            {
                isDigitBullOrCow[3] = true;
                cows++;
            }

            // checks if fourthDigit is cow:
            if (!isDigitBullOrCow[0] && fourthDigit == FirstDigit)
            {
                isDigitBullOrCow[0] = true;
                cows++;
            }
            else if (!isDigitBullOrCow[1] && fourthDigit == SecondDigit)
            {
                isDigitBullOrCow[1] = true;
                cows++;
            }
            else if (!isDigitBullOrCow[2] && fourthDigit == ThirdDigit)
            {
                isDigitBullOrCow[2] = true;
                cows++;
            }

            Result guessResult = new Result();
            guessResult.Bulls = bulls;
            guessResult.Cows = cows;

            return guessResult;
        }

        private void GenerateRandomNumbers()
        {
            this.FirstDigit = randomGenerator.Next(0, 10);
            this.SecondDigit = randomGenerator.Next(0, 10);
            this.ThirdDigit = randomGenerator.Next(0, 10);
            this.FourthDigit = randomGenerator.Next(0, 10);
        }

        public override string ToString()
        {
            StringBuilder numbers = new StringBuilder();
            numbers.Append(FirstDigit);
            numbers.Append(SecondDigit);
            numbers.Append(ThirdDigit);
            numbers.Append(FourthDigit);
            return numbers.ToString();
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
                return (FirstDigit == objectToCompare.FirstDigit &&
                        SecondDigit == objectToCompare.SecondDigit &&
                        ThirdDigit == objectToCompare.ThirdDigit &&
                        FourthDigit == objectToCompare.FourthDigit);
            }
        }

        public override int GetHashCode()
        {
            return FirstDigit.GetHashCode() ^ SecondDigit.GetHashCode() ^ ThirdDigit.GetHashCode() ^ FourthDigit.GetHashCode();
        }
    }
}
