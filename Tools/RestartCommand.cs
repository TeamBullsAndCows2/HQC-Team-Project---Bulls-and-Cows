namespace BullsAndCows.Tools
{
    using System;

    /// <summary>
    /// Handles the restart of the game.
    /// </summary>
    public class RestartCommand : Command
    {
        private const string Name = "restart";
        private readonly GameManager gameManager;

        public RestartCommand(GameManager gameManager)
            : base(Name)
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
