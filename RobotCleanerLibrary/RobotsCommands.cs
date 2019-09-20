using System.Collections.Generic;
using System.Linq;

namespace RobotCleanerLibrary
{
    public class RobotsCommands
    {
        // const int MAX_NUMBER_OF_INPUTS = 4;

        private const int MAX_NUMBER_OF_STEPS = 10000;
        private const int MIN_NUMBER_OF_STEPS = 0;

        private List<string> inputListOfStrings;

        public readonly Commands commandSet;

        public RobotsCommands()
        {
            inputListOfStrings = new List<string>();
            commandSet = new Commands();
        }

        public void AddInput(string inputCoordinates)
        {
            if (!InputsCompleated) // 0 or 10000 - will stop
            {
                if (inputListOfStrings.Count == 0) // first
                    numberOFCommands(inputCoordinates);
                else if (inputListOfStrings.Count == 1) // starting loction
                    setStartingLocation(inputCoordinates);
                else
                    commandSet.commandToMove.Add(parsingCommand(inputCoordinates));

               inputListOfStrings.Add(inputCoordinates);
            }
        }

        private CommandToMove parsingCommand(string inputCoordinates)
        {
            CommandToMove commandToMove = new CommandToMove();

            string[] movementsArray = inputCoordinates.Split(null);

            if(movementsArray.Length > 1)
            {
                switch (movementsArray[0].ToUpper())
                {
                    case "N":
                    case "T":
                        commandToMove.directionToMove = Direction.North;
                        break;
                    case "S":
                    case "B":
                        commandToMove.directionToMove = Direction.South;
                        break;
                    case "E":
                    case "R":
                        commandToMove.directionToMove = Direction.East;
                        break;
                    case "W":
                    case "L":
                        commandToMove.directionToMove = Direction.West;
                        break;
                    default:
                        commandToMove.directionToMove = Direction.Unknown;
                        break;
                }

                commandToMove.numberOfSteps = int.Parse(movementsArray[1]);

                if (commandToMove.numberOfSteps > MAX_NUMBER_OF_STEPS - 1)
                    commandToMove.numberOfSteps = MAX_NUMBER_OF_STEPS;
                if (commandToMove.numberOfSteps < MIN_NUMBER_OF_STEPS + 1)
                    commandToMove.numberOfSteps = MIN_NUMBER_OF_STEPS;
            }

            return commandToMove;
        }

        private void setStartingLocation(string inputCoordinates)
        {
            string[] locationArray = inputCoordinates.Split(null);

            // remove all empty strings
            locationArray = locationArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            if (locationArray.Length > 1)
            {
                int localX = int.Parse(locationArray[0]);
                int localY = int.Parse(locationArray[1]);

                commandSet.startPosition = new Location(localX, localY);
            }
        }

        private void numberOFCommands(string inputCoordinates)
        {
            commandSet.totalNumberOFCommands = int.Parse(inputCoordinates);

            if(commandSet.totalNumberOFCommands < 0) // notify the user of wrong input
                commandSet.totalNumberOFCommands = 0;
            else if (commandSet.totalNumberOFCommands > 10000) // notify the user of wrong input
                commandSet.totalNumberOFCommands = 10000;
        }

        public bool InputsCompleated {
            get {
                return inputListOfStrings.Count == (commandSet.totalNumberOFCommands + 2);
            }
        }

        public Commands GetCommandSet()
        {
            if (InputsCompleated)
                return commandSet;

            return null;
        }
    }
}