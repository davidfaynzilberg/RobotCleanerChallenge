namespace RobotCleanerLibrary
{
    public interface IReport
    {
        string PrintReport();

        void RegisterNewPosition(Location position);
    }
}