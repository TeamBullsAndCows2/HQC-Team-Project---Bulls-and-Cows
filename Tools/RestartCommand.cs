namespace BullsAndCows.Tools
{
    using System;

    public class RestartCommand : Command
    {
        private const string name = "restart";

        public RestartCommand()
            : base(name)
        {
        }

        public override void Execute()
        {
            // Execute REstart Logic here;
        }
    }
}
