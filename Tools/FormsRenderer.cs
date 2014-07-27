namespace BullsAndCows.Common.Tools
{
    using System;
    using System.Collections.Generic;
    using BullsAndCows.Common.Interfaces;
    using System.Windows.Forms;

    public class FormsRenderer : IRenderer
    {
        public void Write(object message)
        {
            MessageBox.Show(message.ToString());
        }

        public void Write(string message, params object[] words)
        {
            MessageBox.Show(String.Format(message, words));
        }

        public void WriteLine(object message)
        {
            MessageBox.Show(message.ToString());
        }

        public void WriteLine()
        {

        }

        public void WriteLine(string message, params object[] words)
        {
            MessageBox.Show(String.Format(message, words));
        }
    }
}
