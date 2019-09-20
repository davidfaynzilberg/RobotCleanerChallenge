using RobotCleanerLibrary;
using System.Collections.Generic;

namespace RobotCleanerTests
{
    class TestReporter : IReport
    {
        private SortedSet<Location> cleanedLocationStrings;
        public string PrintReport()
        {
            return "=> Cleaned: 0";
        }
        public void RegisterNewPosition(Location position)
        {
        }
    }
}