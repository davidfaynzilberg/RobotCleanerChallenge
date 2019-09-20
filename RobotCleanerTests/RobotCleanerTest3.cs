using NUnit.Framework;
using RobotCleanerLibrary;

namespace Tests
{
    public class Tests3
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddingInputsTest3()
        {
            RobotsCommands сommandFactory = new RobotsCommands();
            сommandFactory.AddInput("3");
            сommandFactory.AddInput("0 0");
            сommandFactory.AddInput("W 2");
            сommandFactory.AddInput("N 1");
            сommandFactory.AddInput("W 2");

            Assert.IsTrue(сommandFactory.InputsCompleated);
            // Assert.Pass("AddingInputsTest 3 Completed with {0} Inputs:", сommandFactory.totalNumberOFCommands.ToString(), сommandFactory.InputsCompleated);
        }
    }
}