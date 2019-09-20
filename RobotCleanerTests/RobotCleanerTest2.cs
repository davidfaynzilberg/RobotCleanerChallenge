using NUnit.Framework;
using RobotCleanerLibrary;

namespace Tests
{
    public class Tests2
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddingInputsTest2()
        {
            RobotsCommands сommandFactory = new RobotsCommands();
            сommandFactory.AddInput("2");
            сommandFactory.AddInput("100 200");
            сommandFactory.AddInput("W 2");
            сommandFactory.AddInput("N 1");

            Assert.IsTrue(сommandFactory.InputsCompleated);
            // Assert.Pass("AddingInputsTest 2 Completed with {0} Inputs:", сommandFactory.totalNumberOFCommands.ToString(), сommandFactory.InputsCompleated);
        }
    }
}