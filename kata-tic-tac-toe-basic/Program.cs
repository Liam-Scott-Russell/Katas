using System;

namespace kata_tic_tac_toe_basic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    
    interface IPlayerInputtedMove
    {
        string XCoordinate { get; set; }
        string YCoordinate { get; set; }
    }

    class PlayerInputtedMove
    {
        public string Xcoordinate { get; set; }
        public string Ycoordinate { get; set; }
    }

    interface IBoard
    {
        string[,] CurrentBoardState { get; set; }
    }

    interface IGameState : IBoard
    {
        int CurrentPlayerTurn { get; set; }
    }

    class GameState : IGameState
    {
        public string[,] CurrentBoardState { get; set; }
        public int CurrentPlayerTurn { get; set; }
    }

    class WinConditions
    {
        static int WhichPlayerHasWon(IBoard currentBoard)
        {
            return 0;
        }

        static bool IsGameDraw(IBoard currentBoard)
        {
            return false;
        }
    }

    class PlayerMove
    {
        private string XCoordinate { get; set; }
        private string YCoordinate { get; set; }
        
        public PlayerMove(PlayerInputtedMove inputtedMove)
        {
            
        }

        public bool IsCoordinateValid()
        {
            return true;
        }

        public bool IsCoordinateEmptyOnBoard(IBoard board)
        {
            return false;
        }

        public int[] ToArrayIndices()
        {
            int xCoordinateArrayIndex = Convert.ToInt32(XCoordinate) - 1;
            int yCoordinateArrayIndex = Convert.ToInt32(YCoordinate) - 1;
            return new int[] {xCoordinateArrayIndex, yCoordinateArrayIndex};
        }

        public void DrawOnBoard(IBoard board)
        {
            
        }
        
    }

    class GameController
    {
        public void PlayGame()
        {
            
        }

        public string GetInput()
        {
            return "";
        }
    }
}
