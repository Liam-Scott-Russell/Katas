namespace Game_Of_Life
{
    public class Point
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Point(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }
    }
}