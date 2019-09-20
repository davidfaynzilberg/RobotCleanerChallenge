using NUnit.Framework;
using RobotCleanerLibrary;

namespace Tests
{
    public class CommandTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IncompleteCommandTest()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("3");
            сommandFactory.AddInput("5 25");
            сommandFactory.AddInput("W 2");

            Commands сommandSet = сommandFactory.GetCommandSet();

            Assert.IsNull(сommandSet);
        }

        [Test]
        public void CompleteCommandTest()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("7");
            сommandFactory.AddInput("10 20");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");

            Commands сommandSet = сommandFactory.GetCommandSet();

            Assert.IsNotNull(сommandSet);
        }

        [Test]
        public void CheckIfCommandSetIsCorrectTest()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("11");
            сommandFactory.AddInput("10 20");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("S 10");

            Commands сommandSet = сommandFactory.GetCommandSet();

            Assert.AreEqual(11, сommandSet.commandToMove.Count);
        }
    }
}