namespace BullsAndCows.Tools
{
    using System;

    /// <summary>
    /// Handles user 'help' command.
    /// </summary>
    class HelpCommand : Command
    {
        private const string name = "help";
        private GameManager gameManager;

        public HelpCommand(GameManager gameManager)
            : base(name)
        {
            this.gameManager = gameManager;
        }

        public override void Execute()
        {
            gameManager.Renderer.WriteLine("The number looks like {0}.", gameManager.BullsAndCowsNumbers[gameManager.CurrentPlayerIndex].GetCheat());
            gameManager.NextPlayer();
        }
    }
}
