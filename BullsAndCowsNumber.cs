namespace BullsAndCows
{   
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BullsAndCows.Interfaces;
    using BullsAndCows.Tools;

    /// <summary>
    /// The class handles the generated number guessing and the output from the "help" command.
    /// </summary>
    public class BullsAndCowsNumber
    {
        private Cheat cheatNumber;
        private int[] number;

        public BullsAndCowsNumber(int[] initialNumber)
        {
            this.number = initialNumber;
            this.cheatNumber = new Cheat(number);
            this.GuessesCount = 0;
        }

        public int Cheats
        {
            get
            {
                return cheatNumber.Cheats;
            }
        }

        public int GuessesCount
        {
            get;
            private set;
        }

        public static bool IsValidNumber(string input)
        {
            int number = 0;
            bool result = true;
            bool isNumber = int.TryParse(input, out number);

            if (input.Length != 4)
            {
                result = false;
            }

            if (!isNumber || number < 1000 || 9999 < number)
            {
                result = false;
            }

            return result;
        }

        public string GetCheat()
        {
            return cheatNumber.GetCheat();
        }

        // Engine?
        public Result TryToGuess(string number)
        {
            int guessesCount = this.GuessesCount;
            Result result = Checker.TryToGuess(number, ref guessesCount, this.number);
            this.GuessesCount = guessesCount;

            return result;
        }
       
        // Engine
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
                return this.number[0] == objectToCompare.number[0] &&
                        this.number[1] == objectToCompare.number[1] &&
                        this.number[2] == objectToCompare.number[2] &&
                        this.number[3] == objectToCompare.number[3];
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
