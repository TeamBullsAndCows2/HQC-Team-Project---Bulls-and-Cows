namespace BullsAndCows.Common.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BullsAndCows.Common.Interfaces;

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
