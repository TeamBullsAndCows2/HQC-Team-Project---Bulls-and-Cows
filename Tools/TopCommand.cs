namespace BullsAndCows.Tools
{
    using System;

    public class TopCommand : Command
    {
        private const string name = "top";

        public TopCommand()
            : base(name)
        {
        }

        public override void Execute()
        {
            // Execute 'Top' command logic here;
        }
    }
}
