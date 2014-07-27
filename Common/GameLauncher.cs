namespace BullsAndCows.Common
{
    using System;
    using BullsAndCows.Common.Tools;

    /// <summary>
    /// This is the main method, it relies on the Engine to start the game.
    /// </summary>
    public class GameLauncher
    {
        /// <summary>
        /// The main method, makes an instance of the engine to start the game.
        /// </summary>
        public static void Main()
        {
            Engine engine = new Engine();
            engine.Start();
        }
    }
}
