namespace Game_Of_Life
{
    interface IBoard
    {
        Cell[,] Cells { get; }
        int Width { get; }
        int Height { get; }
    }
    
    public class Board : IBoard
    {
        public Cell[,] Cells { get; }
        public int Width { get; }
        public int Height { get; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[Height, Width];
        }

        public void UpdateCells()
        {
            CalculateCellsNextState();
            
            for (var row = 0; row < Height; row++)
            {
                for (var col = 0; col < Width; col++)
                {
                    Cell currentCell = Cells[row, col];

                    currentCell.IsLiving = currentCell.WillLiveNextRound;
                }
            }
        }

        private void CalculateCellsNextState()
        {
            for (var row = 0; row < Height; row++)
            {
                for (var col = 0; col < Width; col++)
                {
                    Cell currentCell = Cells[row, col];
                    
                    if (currentCell.IsLiving)
                    {
                        currentCell.WillLiveNextRound = GameRules.CellWillLive(currentCell);
                    }
                    else
                    {
                        currentCell.WillLiveNextRound = GameRules.CellWillRevive(currentCell);
                    }
                }
            }
        }

        public void CalculateCellNeighbours()
        {
            for (var row = 0; row < Height; row++)
            {
                for (var col = 0; col < Width; col++)
                {
                    var northPoint = AdjustPointToFitInBoard(new Point(row - 1, col));
                    var northEastPoint = AdjustPointToFitInBoard(new Point(row - 1, col + 1));
                    var eastPoint = AdjustPointToFitInBoard(new Point(row, col + 1));
                    var southEastPoint = AdjustPointToFitInBoard(new Point(row + 1, col + 1));
                    var southPoint = AdjustPointToFitInBoard(new Point(row + 1, col));
                    var southWestPoint = AdjustPointToFitInBoard(new Point(row + 1, col - 1));
                    var westPoint = AdjustPointToFitInBoard(new Point(row, col - 1));
                    var northWestPoint = AdjustPointToFitInBoard(new Point(row - 1, col - 1));
                        
                    var cellNeighbourhood = new Neighbourhood()
                    {
                        North = Cells[northPoint.XCoordinate, northPoint.YCoordinate],
                        NorthEast = Cells[northEastPoint.XCoordinate, northEastPoint.YCoordinate],
                        East = Cells[eastPoint.XCoordinate, eastPoint.YCoordinate],
                        SouthEast = Cells[southEastPoint.XCoordinate, southEastPoint.YCoordinate],
                        South = Cells[southPoint.XCoordinate, southPoint.YCoordinate],
                        SouthWest = Cells[southWestPoint.XCoordinate, southWestPoint.YCoordinate],
                        West = Cells[westPoint.XCoordinate, westPoint.YCoordinate],
                        NorthWest = Cells[northWestPoint.XCoordinate, northWestPoint.YCoordinate]
                    };

                    Cells[row, col].Neighbours = cellNeighbourhood;
                }
            }
        }

        private Point AdjustPointToFitInBoard(Point point)
        {
            point.XCoordinate = NegativeAdjustedModulo(point.XCoordinate, Height);
            point.YCoordinate = NegativeAdjustedModulo(point.YCoordinate, Width);
            return point;
        }

        // C# doesn't actually have a modulo operation, but rather approximates
        //     it using a remainder (so it doesn't work with negatives).
        private int NegativeAdjustedModulo(int x, int m)
        {
            return (x%m + m)%m;
        }
    }
}