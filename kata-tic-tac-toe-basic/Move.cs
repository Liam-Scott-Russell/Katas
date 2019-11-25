using System;
using System.Text.RegularExpressions;

namespace kata_tic_tac_toe_basic
{
    public class Move
    {
        public int[] Coordinates { get; set; }
        private Board GameBoard { get; }
        private string SymbolToWrite { get; set; }

        public Move(string playerMove, GameState currentGameState)
        {
            GameBoard = currentGameState.CurrentBoard;
            SymbolToWrite = currentGameState.CurrentPlayer.Symbol;
            Coordinates = ConvertMoveToIndices(playerMove);
        }

        public static int[] ConvertMoveToIndices(string playerMove)
        {
            var separatedInput = playerMove.Split(",");
            var coordinates = new[]
            {
                Convert.ToInt32(separatedInput[0]) - 1,
                Convert.ToInt32(separatedInput[1]) - 1
            };
            return coordinates;
        }

        public bool IsCoordinatesValid()
        {
            var isXValid = (0 <= Coordinates[0] && Coordinates[0] < GameBoard.BoardDimension);
            var isYValid = (0 <= Coordinates[1] && Coordinates[1] < GameBoard.BoardDimension);
            return isXValid && isYValid;
        }

        public bool IsBoardEmptyAtCoordinates()
        {
            var currentSymbolAtCoordinates = GameBoard[Coordinates[0], Coordinates[1]];
            return currentSymbolAtCoordinates == ".";
        }

        public static bool IsMatchForMoveInputFormat(string possibleMove)
        {
            Regex inputFormatRegex = new Regex(@"^(\d+,\d+)$");
            MatchCollection matches = inputFormatRegex.Matches(possibleMove);
            return matches.Count == 1;
        }

        public void MakeMove()
        {
            GameBoard[Coordinates[0], Coordinates[1]] = SymbolToWrite;
            GameBoard.EmptySpaces--;
        }
    }
}