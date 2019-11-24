namespace kata_tic_tac_toe_basic
{
    interface IGameState : IBoard
    {
        int CurrentPlayerTurn { get; set; }
        int TurnsPlayed { get; set; }
    }

    class GameState : IGameState
    {
        public string[,] CurrentBoardState { get; set; }
        public int CurrentPlayerTurn { get; set; }
        public int TurnsPlayed { get; set; }
    }
}