namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BullsAndCows.Interfaces;
    using BullsAndCows.Tools;

    public class Program
    {
        public static void Main()
        {
            Engine engine = new Engine();
            engine.Start();
        }
    }
}
