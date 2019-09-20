using RobotCleanerLibrary;
using System;

namespace RobotCleanerChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Starts...");
            Console.WriteLine("Ready For Input");
            Console.WriteLine("Example Input:");
            Console.WriteLine("4 (commands)");
            Console.WriteLine("10 10 (start position)");
            Console.WriteLine("W 10 (west 10)");
            Console.WriteLine("N 4 (north 4)");
            Console.WriteLine("E 14 (east 14)");
            Console.WriteLine("5 20 (south 20)");

            RobotsCommands commandFactory = new RobotsCommands();

            while (!commandFactory.InputsCompleated)
            {
                // Adding Robot Inputs
                commandFactory.AddInput(Console.ReadLine());
            }

            Console.WriteLine("Robot Instructions are complete.");
            Console.ReadLine();

            // robot executing input commands
            SimpleReporter jobReporter = new SimpleReporter();
            CleanerRobot cleanerRobot = new CleanerRobot(commandFactory.GetCommandSet(), jobReporter, new Location(0, 0), new Location(12, 12));
            cleanerRobot.Run();

            //give output on the number of places cleaned
            Console.WriteLine(cleanerRobot.PrintReport());
        }
    }
}
