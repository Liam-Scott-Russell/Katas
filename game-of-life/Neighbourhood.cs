using System.Collections.Generic;

namespace Game_Of_Life
{
    public class Neighbourhood
    {
        public Cell North { get; set; }
        public Cell NorthEast { get; set; }
        public Cell East { get; set; }
        public Cell SouthEast { get; set; }
        public Cell South { get; set; }
        public Cell SouthWest { get; set; }
        public Cell West { get; set; }
        public Cell NorthWest { get; set; }

        public Cell[] GetAllNeighbours()
        {
            var allNeighbours = new Cell[8]
            {
                North,
                NorthEast,
                East,
                SouthEast,
                South,
                SouthWest,
                West,
                NorthWest,
            };
            return allNeighbours;
        }
    }
}