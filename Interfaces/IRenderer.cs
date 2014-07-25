namespace BullsAndCows.Interfaces
{
    using System;

    public interface IRenderer
    {
        void Write(object message);
        void Write(string message, params object[] words);

        void WriteLine(object message);
        void WriteLine();
        void WriteLine(string message, params object[] words);
    }
}
