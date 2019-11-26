namespace Game_Of_Life
{
    interface IBoard
    {
        Cell[] Cells { get; }
        int Width { get; }
        int Height { get; }
    }
    
    public class Board : IBoard
    {
        public Cell[] Cells { get; }
        public int Width { get; }
        public int Height { get; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void UpdateCells()
        {
            
        }

        private void CalculateCellsNextState()
        {
            
        }

        public void CalculateCellNeighbours()
        {
            
        }
    }
}