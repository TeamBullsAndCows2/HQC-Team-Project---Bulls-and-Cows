namespace BullsAndCows.Tools
{
    using BullsAndCows.Interfaces;
    using System;
    using System.Collections.Generic;

    public class CommandHandler : ICommandHandler
    {
        Dictionary<string, ICommand> commands;

        public CommandHandler()
        {
            this.commands = new Dictionary<string, ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            if (command == null)
            {
                throw new NullReferenceException("Command cannot be null!");
            }

            this.commands.Add(command.Name, command);
        }

        public bool RemoveCommand(ICommand command)
        {
            if (command == null)
            {
                throw new NullReferenceException("Command cannot be null!");
            }

            return this.commands.Remove(command.Name);
        }

        public void ExecuteCommand(string name)
        {
            this.commands[name].Execute();
        }
    }
}
