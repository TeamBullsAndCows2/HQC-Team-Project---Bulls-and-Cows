namespace BullsAndCows.Tools
{
    using BullsAndCows.Interfaces;
    using System;

    public class ConsoleRenderer : IRenderer
    {
        public ConsoleRenderer()
        { 
        }

        public void Write(Object message)
        {
            Console.Write(message);
        }

        public void Write(string message, params Object[] words)
        {
            Console.Write(message, words);
        }

        public void WriteLine(Object message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string message, params Object[] words)
        {
            Console.WriteLine(message, words);
        }
    }
}
