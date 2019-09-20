using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleanerLibrary
{
    public class Commands
    {
        public Commands()
        {
            _commandToMove = new List<CommandToMove>();
        }

        public int totalNumberOFCommands
        {
            get {
                return _totalNumberOFCommands;
            }
            set {
                _totalNumberOFCommands = value;
            }
        }
        private int _totalNumberOFCommands;

        public Location startPosition
        {
            get {
                return _startPosition;
            }
            set {
                _startPosition = value;
            }
        }
        private Location _startPosition;

        public List<CommandToMove> commandToMove
        {
            get {
                return _commandToMove;
            }
            set {
                commandToMove = value;
            }
        }
        private List<CommandToMove> _commandToMove;
    }
}
