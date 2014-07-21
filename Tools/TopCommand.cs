﻿namespace BullsAndCows.Tools
{
    using System;

    public class TopCommand : Command
    {
        private const string name = "top";
        private GameManager gameManager;

        public TopCommand(GameManager gameManager)
            : base(name)
        {
            this.gameManager = gameManager;
        }

        public override void Execute()
        {
            gameManager.Renderer.WriteLine(gameManager.ScoreBoard);
        }
    }
}
