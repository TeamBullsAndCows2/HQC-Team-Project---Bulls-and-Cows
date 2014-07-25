namespace BullsAndCows.Tools
{
    using BullsAndCows.Interfaces;
    using System;

    public class ConsoleRenderer : IRenderer
    {
        public ConsoleRenderer()
        { 
        }

        public void Write(object message)
        {
            Console.Write(message);
        }

        public void Write(string message, params object[] words)
        {
            Console.Write(message, words);
        }

        public void WriteLine(object message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string message, params object[] words)
        {
            Console.WriteLine(message, words);
        }
    }
}
