namespace kata_tic_tac_toe_basic
{
    interface IGameState
    {
        Player CurrentPlayer { get; set; }
        Board CurrentBoard { get; set; }
        Player[] AllPlayers { get; set; }
    }

    public class GameState : IGameState
    {
        public Board CurrentBoard { get; set; }
        public Player CurrentPlayer { get; set; }
        public Player[] AllPlayers { get; set; }
    }
}