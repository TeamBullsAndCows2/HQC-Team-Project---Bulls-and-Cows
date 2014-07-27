namespace BullsAndCows.Common.Interfaces
{
    using System;

    /// <summary>
    /// An interface for the messages to be given to the player.
    /// </summary>
    public interface IRenderer
    {
        void Write(object message);
        void Write(string message, params object[] words);

        void WriteLine(object message);
        void WriteLine();
        void WriteLine(string message, params object[] words);
    }
}
