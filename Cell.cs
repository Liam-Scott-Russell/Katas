namespace Game_Of_Life
{
    public interface ICell
    {
        Cell[] Neighbours { get; set; }
        bool IsLiving { get; set; }
        Point Coordinates { get; }
        bool WillLiveNextRound { get; set; }
    }
    public class Cell : ICell
    {
        public Cell[] Neighbours { get; set; } = new Cell[8];
        public bool IsLiving { get; set; }
        public Point Coordinates { get; }
        public bool WillLiveNextRound { get; set; }

        public Cell(Point coordinates, bool isLiving)
        {
            Coordinates = coordinates;
            IsLiving = isLiving;
        }

        private bool IsUnderPopulated()
        {
            return false;
        }

        private bool IsOverCrowded()
        {
            return false;
        }

        private bool IsGoingToSurvive()
        {
            return false;
        }

        private bool IsGoingToRevive()
        {
            return false;
        }
    }
}