namespace BullsAndCows
{
    using BullsAndCows.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name cannot be null! Please enter a valid name!");
                }

                this.name = value.Trim();
            }
        }

        public string GetInput()
        {
            // TODO: Refactor
            string input = Console.ReadLine().Trim();
            return input;
        }
    }
}
