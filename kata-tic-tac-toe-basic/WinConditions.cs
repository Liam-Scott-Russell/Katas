namespace kata_tic_tac_toe_basic
{
    class WinConditions
    {
        public static int WhichPlayerHasWon(GameState currentBoard)
        {
            return 0;
        }

        public static bool IsGameDraw(GameState currentBoard)
        {
            int boardRowHeight = currentBoard.CurrentBoardState.GetLength(0);
            int numberOfSlotsInBoard = boardRowHeight * boardRowHeight;
            return (currentBoard.TurnsPlayed + 1) < numberOfSlotsInBoard; // +1 because turns starts off as 0
        }
    }
}