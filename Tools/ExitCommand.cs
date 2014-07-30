namespace BullsAndCows.Common.Tools
{
    using System;

    /// <summary>
    /// Handles 'exit' user command.
    /// </summary>
    public class ExitCommand : Command
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
            this.gameManager.IsRunning = false;
            this.gameManager.Renderer.WriteLine(GameManager.GoodBuyMessage);
        }
    }
}
