namespace BullsAndCows.Common.Interfaces
{
    using System;

    /// <summary>
    /// The interface responsible for handling a command.
    /// </summary>
    public interface ICommandHandler
    {
        /// <summary>
        /// Adds a command.
        /// </summary>
        /// <param name="command">Name of the command.</param>
        void AddCommand(ICommand command);

        /// <summary>
        /// Removes a command.
        /// </summary>
        /// <param name="command">Name of the command.</param>
        /// <returns>Returns true or false.</returns>
        bool RemoveCommand(ICommand command);

        /// <summary>
        /// Executes the given command.
        /// </summary>
        /// <param name="commandName">Name of the command.</param>
        void ExecuteCommand(string commandName);
    }
}
