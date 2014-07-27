namespace BullsAndCows.Common.Tools
{
    using BullsAndCows.Common.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Gets the player's input from the console.
    /// </summary>
    public class ConsoleInputManager : IInputManager
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
