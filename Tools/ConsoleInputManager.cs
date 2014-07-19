namespace BullsAndCows.Tools
{
    using BullsAndCows.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ConsoleInputManager : IInputManager
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
