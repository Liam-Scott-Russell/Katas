namespace kata_tic_tac_toe_basic
{
    interface IBoard
    {
        string[,] CurrentBoardState { get; set; }
    }
}