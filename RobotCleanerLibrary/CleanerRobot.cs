using System;
using System.Collections.Generic;
using RobotCleanerLibrary;

namespace RobotCleanerLibrary
{
    public class CleanerRobot
    {
        public Location location { get; set; }
        private Commands commandSet;
        public readonly IReport reporter;
        public readonly Location bottomLeftLocation;
        public readonly Location topRightLocation;

        public CleanerRobot(Commands commandSet, IReport reporter) : this(commandSet, reporter, null, null)
        {
        }

        public CleanerRobot(Commands commandSet, IReport reporter, Location topRightLocation, Location bottomLeftLocation)
        {
            this.commandSet = commandSet;
            this.location = commandSet.startPosition;
            this.topRightLocation = topRightLocation;
            this.bottomLeftLocation = bottomLeftLocation;
            this.reporter = reporter;
        }

        public void Run()
        {
            foreach (CommandToMove step in commandSet.commandToMove)
            {
                for (int i = 0; i < step.numberOfSteps; i++)
                {
                    MakeRobotMove(step);
                }
            }
        }

        private void MakeRobotMove(CommandToMove step)
        {
            switch (step.directionToMove)
            {
                case Direction.North:
                    location = new Location(location.x, location.y + 1);
                    break;
                case Direction.East:
                    location = new Location(location.x + 1, location.y);
                    break;
                case Direction.South:
                    location = new Location(location.x, location.y - 1);
                    break;
                case Direction.West:
                    location = new Location(location.x - 1, location.y);
                    break;
            }

            // make sure we still in the room
            location.Validate(bottomLeftLocation, topRightLocation);

            if ( reporter != null )
                reporter.RegisterNewPosition(location);
        }

        public string PrintReport()
        {
            if (reporter == null)
                return "=> Cleaned: unknown";

            return reporter.PrintReport();
        }
    }
}