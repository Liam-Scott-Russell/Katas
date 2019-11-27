namespace Game_Of_Life
{
    public static class GameRules
    {
        public static bool CellWillLive(Cell cell)
        {
            var livingNeighbourCount = GetNumberOfLivingNeighbours(cell);

            var cellIsUnderPopulated = livingNeighbourCount < 2;
            var cellIsOverCrowded = livingNeighbourCount > 3;
            
            return !(cellIsOverCrowded || cellIsUnderPopulated);
        }

        public static bool CellWillRevive(Cell cell)
        {
            var livingNeighbourCount = GetNumberOfLivingNeighbours(cell);

            var cellWillRevive = livingNeighbourCount == 3;
            
            return cellWillRevive;
        }

        private static int GetNumberOfLivingNeighbours(Cell cell)
        {
            var livingNeighbourCount = 0;
            
            foreach (var neighbour in cell.Neighbours.GetAllNeighbours())
            {
                if (neighbour.IsLiving)
                {
                    livingNeighbourCount++;
                }
            }

            return livingNeighbourCount;
        }
    }
}