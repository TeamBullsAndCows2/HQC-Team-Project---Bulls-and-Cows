namespace BullsAndCows.Tools
{
    using BullsAndCows.Interfaces;
    using System;

    public abstract class Command : ICommand
    {
        private string name;

        public Command(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get 
            {
                return this.name;
            }
        }

        public abstract void Execute();
    }
}
