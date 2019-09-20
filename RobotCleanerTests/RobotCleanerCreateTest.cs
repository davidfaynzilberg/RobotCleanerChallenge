using NUnit.Framework;
using RobotCleanerLibrary;

namespace RobotCleanerTests
{
    public class RobotCleanerCreateTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateRobotTest()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("0");
            сommandFactory.AddInput("0 0");

            Commands commandSet = сommandFactory.GetCommandSet();

            CleanerRobot cleanerRobot = new CleanerRobot(commandSet, null);

            Assert.IsTrue(сommandFactory.InputsCompleated);
        }

        [Test]
        public void MovingRobotTest()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("4");
            сommandFactory.AddInput("0 0");
            сommandFactory.AddInput("N 10");
            сommandFactory.AddInput("E 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("W 10");

            Commands commandSet = сommandFactory.GetCommandSet();

            CleanerRobot cleanerRobot = new CleanerRobot(commandSet, null);

            // moving the robot
            cleanerRobot.Run();

            Assert.AreEqual(commandSet.startPosition.x, cleanerRobot.location.x);
            Assert.AreEqual(commandSet.startPosition.y, cleanerRobot.location.y);
        }

        [Test]
        public void RobotCleanerReport()
        {
            RobotsCommands сommandFactory = new RobotsCommands();

            сommandFactory.AddInput("4");
            сommandFactory.AddInput("0 0");
            сommandFactory.AddInput("N 10");
            сommandFactory.AddInput("E 10");
            сommandFactory.AddInput("S 10");
            сommandFactory.AddInput("W 10");

            Commands commandSet = сommandFactory.GetCommandSet();

            // creating the report
            IReport testReporter = new SimpleReporter();

            // creating the robot
            CleanerRobot cleanerRobot = new CleanerRobot(commandSet, testReporter);

            // moving the robot
            cleanerRobot.Run();

            // gethering the report
            string whereHaveYouBeen = cleanerRobot.PrintReport();

            // Assert.AreEqual("=> Cleaned: 0", whereHaveYouBeen);
            // We are doing complete loop 
            // And Robot comming back to 0 0

            Assert.AreEqual("=> Cleaned: 40", whereHaveYouBeen);
            Assert.AreEqual(commandSet.startPosition.x, cleanerRobot.location.x);
            Assert.AreEqual(commandSet.startPosition.y, cleanerRobot.location.y);
        }
    }
}
