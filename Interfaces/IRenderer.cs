namespace BullsAndCows.Interfaces
{
    using System;

    public interface IRenderer
    {
        void Write(Object message);
        void Write(string message, params Object[] words);

        void WriteLine(Object message);
        void WriteLine();
        void WriteLine(string message, params Object[] words);
    }
}
