namespace BullsAndCows.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IPlayer
    {
        string Name { get; }

        string GetInput();
    }
}
