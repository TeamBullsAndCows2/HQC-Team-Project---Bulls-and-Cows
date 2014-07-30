using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Common.Interfaces;
using BullsAndCows.Common.Tools;

namespace BullsAndCows.Common.Test
{
    [TestClass]
    public class ConsoleRendererTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestWrite_WithNull()
        {
            IRenderer renderer = new ConsoleRenderer();
            renderer.Write(null);
        }

        [TestMethod]
        public void TestWrite_WithNewObject()
        {
            IRenderer renderer = new ConsoleRenderer();
            renderer.Write(new object());
        }

        [TestMethod]
        public void TestWrite_WithMessageAndParams()
        {
            IRenderer renderer = new ConsoleRenderer();
            renderer.Write("message {0} {1}", "zero", "one");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestWrite_WithMessageAndNotEnoughParams()
        {
            IRenderer renderer = new ConsoleRenderer();
            renderer.Write("message {0} {1}", "one");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestWriteLine_WithNull()
        {
            IRenderer renderer = new ConsoleRenderer();
            renderer.WriteLine(null);
        }

        [TestMethod]
        public void TestWriteLine_WithNewObject()
        {
            IRenderer renderer = new ConsoleRenderer();
            renderer.WriteLine(new object());
        }

        [TestMethod]
        public void TestWriteLine_WithMessageAndParams()
        {
            IRenderer renderer = new ConsoleRenderer();
            renderer.WriteLine("message {0} {1}", "zero", "one");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestWriteLine_WithMessageAndNotEnoughParams()
        {
            IRenderer renderer = new ConsoleRenderer();
            renderer.WriteLine("message {0} {1}", "one");
        }
    }
}
