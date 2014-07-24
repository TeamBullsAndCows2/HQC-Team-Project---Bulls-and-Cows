namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BullsAndCows.Interfaces;
    using BullsAndCows.Tools;

    /// <summary>
    /// This is the main method, it relies on the Engine to start the game.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Engine engine = new Engine();
            engine.Start();
        }
    }
}
