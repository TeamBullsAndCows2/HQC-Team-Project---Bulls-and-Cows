namespace BullsAndCows.Tools
{
    using System;

    public class TopCommand : Command
    {
        private const string Name = "top";
        private readonly GameManager gameManager;

        public TopCommand(GameManager gameManager)
            : base(Name)
        {
            this.gameManager = gameManager;
        }

        public override void Execute()
        {
            this.gameManager.Renderer.WriteLine(gameManager.ScoreBoard);
        }
    }
}
