namespace BullsAndCows.Common.Interfaces
{
    using System;

    /// <summary>
    /// The interface for the command handling.
    /// </summary>
    public interface ICommand
    {
        string Name { get; }

        /// <summary>
        /// Executes the command.
        /// </summary>
        void Execute();
    }
}
