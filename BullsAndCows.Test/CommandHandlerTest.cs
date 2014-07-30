using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Common.Tools;
using BullsAndCows.Common.Interfaces;

namespace BullsAndCows.Common.Test
{
    [TestClass]
    public class CommandHandlerTest
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestAddCommand_AddCommandAsNull()
        {
            CommandHandler commandHandler = new CommandHandler();

            commandHandler.AddCommand(null);
        }

        [TestMethod]
        public void TestAddCommand_AddNewCommand()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputManager inputMeneger = new ConsoleInputManager();
            GameManager gm = new GameManager(renderer, inputMeneger);
            CommandHandler commandHandler = new CommandHandler();

            ICommand newRestartCMD = new RestartCommand(gm);
            commandHandler.AddCommand(newRestartCMD);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestRemoveCommand_RemoveCommandAsNull()
        {
            CommandHandler commandHandler = new CommandHandler();

            commandHandler.RemoveCommand(null);
        }

        [TestMethod]
        public void TestRemoveCommand_RemoveExistingCommandl()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputManager inputMeneger = new ConsoleInputManager();
            GameManager gm = new GameManager(renderer, inputMeneger);
            CommandHandler commandHandler = new CommandHandler();
            
            ICommand newRestartCMD = new RestartCommand(gm);
            commandHandler.AddCommand(newRestartCMD);
            commandHandler.RemoveCommand(newRestartCMD);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestExecuteCommand_ExecuteCommandNotExistingCommand()
        {
            CommandHandler commandHandler = new CommandHandler();

            commandHandler.ExecuteCommand("NotExistingCommand");
        }
    }
}
