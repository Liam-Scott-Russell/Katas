using System;
using System.Collections.Generic;

namespace kata_tic_tac_toe_basic
{
    class RawPlayerMove
    {
        public string XCoordinate { get; set; }
        public string YCoordinate { get; set; }
    }

    class PlayerMove : RawPlayerMove
    {
        private GameState Board { get; set; }
        private int[] Indices { get; set; }

        private Dictionary<int, string> PlayerToSymbolMapping { get; set; } = new Dictionary<int, string>
        {
            {1, "X"},
            {2, "O"}
        };

        public PlayerMove(RawPlayerMove inputtedMove, GameState board)
        {
            XCoordinate = inputtedMove.XCoordinate;
            YCoordinate = inputtedMove.YCoordinate;
            Board = board;
            Indices = ToArrayIndices();
        }

        public bool IsCoordinateValid()
        {
            bool isRowValid = 0 <= Indices[0] && Indices[0] <= 2;
            bool isColValid = 0 <= Indices[1] && Indices[1] <= 2;
            return isRowValid && isColValid;
        }

        public bool IsCoordinateEmptyOnBoard()
        {

            string currentSymbolOnBoard = Board.CurrentBoardState[Indices[0], Indices[1]];
            return (currentSymbolOnBoard == ".");
        }

        public int[] ToArrayIndices()
        {
            int xCoordinateArrayIndex = Convert.ToInt32(XCoordinate) - 1;
            int yCoordinateArrayIndex = Convert.ToInt32(YCoordinate) - 1;
            return new int[] {xCoordinateArrayIndex, yCoordinateArrayIndex};
        }

        public void DrawOnBoard()
        {
            string playerSymbol = PlayerToSymbolMapping[Board.CurrentPlayerTurn];
            Board.CurrentBoardState[Indices[0], Indices[1]] = playerSymbol;
            Board.TurnsPlayed++;
        }
        
    }
}