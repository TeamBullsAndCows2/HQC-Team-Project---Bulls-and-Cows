namespace BullsAndCows.Tools
{
    using System;

    /// <summary>
    /// Handles 'exit' user command.
    /// </summary>
    class ExitCommand : Command
    {
        private const string Name = "exit";
        private GameManager gameManager;

        public ExitCommand(GameManager gameManager)
            : base(Name)
        {
            this.gameManager = gameManager;
        }

        public override void Execute()
        {
            gameManager.IsRunning = false;
            gameManager.Renderer.WriteLine(GameManager.GoodBuyMessage);
        }
    }
}
