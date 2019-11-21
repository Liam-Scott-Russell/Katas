using System;

namespace kata_tic_tac_toe_basic
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController game = new GameController();
            game.PlayGame();
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
        private GameState Game { get; set; } = new GameState();

        public GameController()
        {
            string[,] blankBoard = new string[,] {{".", ".", "."}, {".", ".", "."}, {".", ".", "."}};
            Game.CurrentBoardState = blankBoard;
            Game.CurrentPlayerTurn = 1;
        }
        public void PlayGame()
        {
            PrintCurrentBoard();
        }

        public string GetInput()
        {
            return "";
        }

        public void PrintCurrentBoard()
        {
            Console.Out.WriteLine("Move accepted, here's the current board:");
            int rowLength = Game.CurrentBoardState.GetLength(0);
            int colLength = Game.CurrentBoardState.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", Game.CurrentBoardState[i, j]));
                }
                Console.Write(Environment.NewLine);
            }

        }
    }
}
