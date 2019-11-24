namespace kata_tic_tac_toe_basic
{
    interface IBoard
    {
        string[][] Rows { get; }
        string[][] Columns { get;  }
        string[][] Diagonals { get; }
        int EmptySpaces { get; set; }
        int BoardDimension { get; set; }

    }

    public class Board : IBoard
    {
        private string[][] _boardState;
        public int BoardDimension { get; set; }

        public string[][] Rows
        {
            // Board is sorted by rows by default.
            get { return _boardState; }
        }

        public string[][] Columns
        {
            get { return Transposed(); }
        }

        public string[][] Diagonals
        {
            get
            {
                var diagonals = new string[2][];
                diagonals[0] = GetPositiveDiagonal();
                diagonals[1] = GetNegativeDiagonal();
                return diagonals;
            }
        }
        public int EmptySpaces { get; set; }

        public Board()
        {
            BoardDimension = 3;
            EmptySpaces = BoardDimension * BoardDimension;
            SetBoardToBlank();
        }

        public string this[int xCoordinate, int yCoordinate]
        {
            get { return _boardState[xCoordinate] [yCoordinate]; }
            set { _boardState[xCoordinate][yCoordinate] = value; }
        }

        private string[][] Transposed()
        {
            var cols = new string[BoardDimension][];
                
            for (var rowNum = 0; rowNum < BoardDimension; rowNum++)
            {
                // Necessary to do this to instantiate the object.
                cols[rowNum] = new string[BoardDimension];
                    
                for (var colNum = 0; colNum < BoardDimension; colNum++)
                {
                    cols[rowNum][colNum] = _boardState[colNum][rowNum];
                }
            }

            return cols;
        }

        private string[] GetPositiveDiagonal()
        {
            var diagonal = new string[BoardDimension];
            for (var i = 0; i < BoardDimension; i++)
            {
                var columnIndex = BoardDimension - i - 1;
                diagonal[i] = _boardState[i][columnIndex];
            }

            return diagonal;
        }

        private string[] GetNegativeDiagonal()
        {
            var diagonal = new string[BoardDimension];
            for (var i = 0; i < BoardDimension; i++)
            {
                diagonal[i] = _boardState[i][i];
            }

            return diagonal;
        }

        private void SetBoardToBlank()
        {
            _boardState = new string[BoardDimension][];
            for (var rowNum = 0; rowNum < BoardDimension; rowNum++)
            {
                _boardState[rowNum] = new string[BoardDimension];
                for (var colNum = 0; colNum < BoardDimension; colNum++)
                {
                    _boardState[rowNum][colNum] = ".";
                }
            }
        }
    }
}