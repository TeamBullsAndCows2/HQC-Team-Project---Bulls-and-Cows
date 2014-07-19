namespace BullsAndCows.Interfaces
{
    using System;

    public interface ICommandHandler
    {
        void AddCommand(ICommand command);

        bool RemoveCommand(ICommand command);

        void ExecuteCommand(string commandName);
    }
}
