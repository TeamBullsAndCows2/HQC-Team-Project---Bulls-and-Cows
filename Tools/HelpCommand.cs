namespace BullsAndCows.Tools
{
    using System;

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
            // TODO: NOT HERE!
            gameManager.CurrentPlayerIndex = (gameManager.CurrentPlayerIndex + 1) % gameManager.Players.Count;
        }
    }
}
