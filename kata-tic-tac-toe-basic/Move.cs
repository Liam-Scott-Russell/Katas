using System;

namespace kata_tic_tac_toe_basic
{
    public class Move
    {
        private int[] Coordinates { get; set; }
        private Board GameBoard { get; }
        private string SymbolToWrite { get; set; }

        public Move(string playerMove, GameState currentGameState)
        {
            Coordinates = ConvertMoveToIndices(playerMove);
            GameBoard = currentGameState.CurrentBoard;
            SymbolToWrite = currentGameState.CurrentPlayer.Symbol;
        }

        private int[] ConvertMoveToIndices(string playerMove)
        {
            string[] separatedInput = playerMove.Split(",");
            int[] coordinates = new int[]
            {
                Convert.ToInt32(separatedInput[0]) - 1,
                Convert.ToInt32(separatedInput[1]) - 1
            };
            return coordinates;
        }

        public bool IsValid()
        {
            return IsCoordinatesValid() && IsBoardEmptyAtCoordinates();
        }

        private bool IsCoordinatesValid()
        {
            var isXValid = (0 <= Coordinates[0] && Coordinates[0] < GameBoard.BoardDimension);
            var isYValid = (0 <= Coordinates[1] && Coordinates[1] < GameBoard.BoardDimension);
            return isXValid && isYValid;
        }

        private bool IsBoardEmptyAtCoordinates()
        {
            string currentSymbolAtCoordinates = GameBoard[Coordinates[0], Coordinates[1]];
            return currentSymbolAtCoordinates == ".";
        }

        public void MakeMove()
        {
            GameBoard[Coordinates[0], Coordinates[1]] = SymbolToWrite;
            GameBoard.EmptySpaces--;
        }
    }
}