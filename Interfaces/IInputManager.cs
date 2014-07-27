namespace BullsAndCows.Common.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Interface that manages the player's input.
    /// </summary>
    public interface IInputManager
    {
        /// <summary>
        /// Gets the player's input.
        /// </summary>
        /// <returns>Returns the input as a string.</returns>
        string GetUserInput();
    }
}
