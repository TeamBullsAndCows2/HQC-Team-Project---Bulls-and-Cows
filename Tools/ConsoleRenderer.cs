using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsAndCowsGame.Interfaces;

namespace BullsAndCowsGame.Tools
{
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
