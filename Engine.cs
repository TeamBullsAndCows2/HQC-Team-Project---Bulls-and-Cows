namespace BullsAndCows
{
    using BullsAndCows.Tools;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private readonly GameManager manager = new GameManager(new ConsoleRenderer(), new ConsoleInputManager());

        public void Start()
        {
            /// Show splash screen
            Console.WriteLine("WelcomeMessage");

            while (manager.IsRunning)
            {
                manager.HandleUserCommand();
            }

            // Scores
        }
    }
}
