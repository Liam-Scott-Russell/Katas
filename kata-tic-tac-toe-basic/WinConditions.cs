using System;
using System.Linq;

namespace kata_tic_tac_toe_basic
{
    class WinConditions
    {
        public static bool PlayerHasWon(Board currentBoard, Player player)
        {
            var winningRun = new string[currentBoard.BoardDimension];
            for (var i = 0; i < winningRun.Length; i++)
            {
                winningRun[i] = player.Symbol;
            }

            var columnMatch = Array.Exists(currentBoard.Columns, column => column.SequenceEqual(winningRun));
            var rowMatch = Array.Exists(currentBoard.Rows, row => row.SequenceEqual(winningRun));
            var diagonalMatch = Array.Exists(currentBoard.Diagonals, diagonal => diagonal.SequenceEqual(winningRun));

            return columnMatch || rowMatch || diagonalMatch;
        }

        public static bool IsGameDraw(Board currentBoard)
        {
            return (currentBoard.EmptySpaces == 0);
        }
        
    }
}