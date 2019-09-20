using NUnit.Framework;
using RobotCleanerLibrary;

namespace Tests
{
    public class Tests4
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddingInputsTest4()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("0");
            сommandFactory.AddInput("40 66");

            Assert.IsTrue(сommandFactory.InputsCompleated);
        }

        [Test]
        public void AddingInputsTest5()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("10000");
            сommandFactory.AddInput("1111 222");

            for (int cnt = 0; cnt < 10000; cnt++)
                сommandFactory.AddInput(cnt.ToString());

            Assert.IsTrue(сommandFactory.InputsCompleated);
        }

        [Test]
        public void AddingInputsTest6()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("10001");
            сommandFactory.AddInput("1111 222");

            for (int cnt = 0; cnt < 30000; cnt++)
                сommandFactory.AddInput(cnt.ToString());

            Assert.IsTrue(сommandFactory.InputsCompleated);
        }
    }
}