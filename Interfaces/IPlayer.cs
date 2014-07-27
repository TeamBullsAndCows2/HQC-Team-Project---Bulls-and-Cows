namespace BullsAndCows.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// An interface for the player's name.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Gets the player's name.
        /// </summary>
        string Name { get; }

        string GetInput();
    }
}
