using NUnit.Framework;
using RobotCleanerLibrary;

namespace Tests
{
    public class Tests1
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddingInputsTest1()
        {
            // Example input:
            // 2
            // 10 22
            // E 2
            // N 1

            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("2");
            сommandFactory.AddInput("10 22");
            сommandFactory.AddInput("E 2");
            сommandFactory.AddInput("N 1");

            Assert.IsTrue(сommandFactory.InputsCompleated);
            // Assert.Pass("AddingInputsTest 1 Completed with {0} Inputs:", сommandFactory.totalNumberOFCommands.ToString(), сommandFactory.InputsCompleated);
        }
    }
}