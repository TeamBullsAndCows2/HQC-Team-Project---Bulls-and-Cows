﻿namespace BullsAndCows.Common.Tools
{
    using System;
    using BullsAndCows.Common.Interfaces;

    /// <summary>
    /// Base Command class. All commands should implement it. Implemented using bridge design pattern together with CommandHandler.
    /// </summary>
    public abstract class Command : ICommand
    {
        private string name;

        public Command(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get 
            {
                return this.name;
            }
        }

        public abstract void Execute();
    }
}
