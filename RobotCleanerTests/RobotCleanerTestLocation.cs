using NUnit.Framework;
using RobotCleanerLibrary;

namespace Tests
{
    public class TestsLocation
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreatePosition()
        {
            Location location = new Location(400, 600);

            Assert.AreEqual(400, location.x);
            Assert.AreEqual(600, location.y);
        }

        [Test]
        public void SetGoodPosition()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("0");
            сommandFactory.AddInput("101 202");

            Location location = new Location(400, 600);

            Assert.AreEqual(101, сommandFactory.commandSet.startPosition.x);
            Assert.AreEqual(202, сommandFactory.commandSet.startPosition.y);
        }

        [Test]
        public void SetBadPosition()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("111");
            сommandFactory.AddInput("101\n202");

            Assert.AreEqual(101, сommandFactory.commandSet.startPosition.x);
            Assert.AreEqual(202, сommandFactory.commandSet.startPosition.y);
        }

        [Test]
        public void SetReallyGoodPosition()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("222");
            сommandFactory.AddInput("101 202");

            Assert.AreEqual(101, сommandFactory.commandSet.startPosition.x);
            Assert.AreEqual(202, сommandFactory.commandSet.startPosition.y);
        }

        [Test]
        public void SetReallyBad1Position()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("222");
            сommandFactory.AddInput("101                                          202");

            Assert.AreEqual(101, сommandFactory.commandSet.startPosition.x);
            Assert.AreEqual(202, сommandFactory.commandSet.startPosition.y);
        }

        [Test]
        public void SetReallyBad2Position()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("333");
            сommandFactory.AddInput("101                 \n                     202");

            Assert.AreEqual(101, сommandFactory.commandSet.startPosition.x);
            Assert.AreEqual(202, сommandFactory.commandSet.startPosition.y);
        }

        [Test]
        public void MovementTest()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("3");
            сommandFactory.AddInput("10 22");
            сommandFactory.AddInput("E 100");

            Assert.AreEqual(1, сommandFactory.commandSet.commandToMove.Count);
        }

        [Test]
        public void MovementMaxTest()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("1");
            сommandFactory.AddInput("100 200");
            сommandFactory.AddInput("N 50000");

            CommandToMove cmmandToMove = сommandFactory.commandSet.commandToMove[0];

            Assert.AreEqual(10000, cmmandToMove.numberOfSteps);
        }
    }
}