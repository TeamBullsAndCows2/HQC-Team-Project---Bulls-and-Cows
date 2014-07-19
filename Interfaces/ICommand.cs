namespace BullsAndCows.Interfaces
{
    using System;

   public interface ICommand
    {
        string Name { get; }

        void Execute();
    }
}
