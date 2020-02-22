namespace kata_tic_tac_toe_basic
{
    interface IPlayer
    {
        string Symbol { get; set; }
        int Number { get; set; }
        bool IsBot { get; set; }
    }
    public class Player : IPlayer
    {
        public string Symbol { get; set; }
        public int Number { get; set; }
        public bool IsBot { get; set; }
    }
}