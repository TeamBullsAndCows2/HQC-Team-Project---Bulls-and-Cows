namespace BullsAndCows.Tools
{
    using System;

    public class RestartCommand : Command
    {
        private const string name = "restart";
        private GameManager gameManager;

        public RestartCommand(GameManager gameManager)
            : base(name)
        {
            this.gameManager = gameManager;
        }

        public override void Execute()
        {
            gameManager.Renderer.WriteLine();
            gameManager.Renderer.WriteLine(GameManager.WelcomeMessage);
            gameManager.StartNewGame();
        }
    }
}
