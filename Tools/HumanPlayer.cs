namespace BullsAndCows.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BullsAndCows.Common.Interfaces;

    /// <summary>
    /// The class reads user's input for player name.
    /// </summary>
    public class HumanPlayer : IPlayer
    {
        private string name;

        public HumanPlayer(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name cannot be null! Please enter a valid name!");
                }

                this.name = value.Trim();
            }
        }

        /// <summary>
        /// Gets the input from the console.
        /// </summary>
        /// <returns>Returns the input in a correct format.</returns>
        public string GetInput()
        {
            // TODO: Refactor
            string input = Console.ReadLine().Trim();
            return input;
        }
    }
}
