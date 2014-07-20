using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        string GetInput();
    }
}
