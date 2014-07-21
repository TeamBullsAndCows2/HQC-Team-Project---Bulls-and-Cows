namespace BullsAndCows.Tools
{
    using System;

    class ExitCommand : Command
    {
        private const string name = "exit";
        private GameManager gameManager;

        public ExitCommand(GameManager gameManager)
            : base(name)
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
