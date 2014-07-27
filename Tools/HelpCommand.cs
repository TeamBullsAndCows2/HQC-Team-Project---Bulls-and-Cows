namespace BullsAndCows.Tools
{
    using System;

    /// <summary>
    /// Handles user "help" command.
    /// </summary>
    class HelpCommand : Command
    {
        private const string Name = "help";
        private GameManager gameManager;

        public HelpCommand(GameManager gameManager)
            : base(Name)
        {
            this.gameManager = gameManager;
        }

        /// <summary>
        /// Visualize the result of the "help command".
        /// </summary>
        public override void Execute()
        {
            gameManager.Renderer.WriteLine("The number looks like {0}.", gameManager.BullsAndCowsNumbers[gameManager.CurrentPlayerIndex].GetCheat());
            gameManager.NextPlayer();
        }
    }
}
