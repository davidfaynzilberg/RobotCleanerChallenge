using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleanerLibrary
{
    public class CommandToMove
    {
        internal Direction
        directionToMove { get; set; }

        public int numberOfSteps { get; set; }
    }
}
