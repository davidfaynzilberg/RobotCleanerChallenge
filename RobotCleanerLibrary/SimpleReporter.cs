using System.Collections.Generic;

namespace RobotCleanerLibrary
{
    public class SimpleReporter : IReport
    {
        private SortedSet<Location> cleanedLocationStrings;

        public SimpleReporter()
        {
            cleanedLocationStrings = new SortedSet<Location>();
        }

        public string PrintReport()
        {
            return string.Format("=> Cleaned: {0}", cleanedLocationStrings.Count);
        }

        public void RegisterNewPosition(Location position)
        {
            if (!cleanedLocationStrings.Contains(position)) // make sure we have unique list
                cleanedLocationStrings.Add(position);
        }
    }
}
