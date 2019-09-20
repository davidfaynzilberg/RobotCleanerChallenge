using System;

namespace RobotCleanerLibrary
{
    public class Location : IComparable<Location>
    {
        private int xPosition;
        private int yPosition;

        public override string ToString()
        {
            return xPosition + "|" + yPosition;
        }

        public int CompareTo(Location other)
        {
            if (this.x == other.x)
                return this.y.CompareTo(other.y);
            return this.x.CompareTo(other.x);
        }

        public Location(int x, int y)
        {
            this.xPosition = x;
            this.yPosition = y;
        }

        public int x
        {
            get { return xPosition; }
        }

        public int y
        {
            get { return yPosition; }
        }

        internal void Validate(Location bottomLeftCorner, Location topRightCorner)
        {
            if (bottomLeftCorner != null)
            {
                if (xPosition < bottomLeftCorner.x)
                    xPosition = bottomLeftCorner.x;
                if (yPosition < bottomLeftCorner.y)
                    yPosition = bottomLeftCorner.y;
            }
            if (topRightCorner != null)
            {
                if (xPosition > topRightCorner.x)
                    xPosition = topRightCorner.x;
                if (yPosition > topRightCorner.y)
                    yPosition = topRightCorner.y;
            }

        }
    }
}