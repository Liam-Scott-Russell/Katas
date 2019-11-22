using System;
using System.Collections.Generic;

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
    
    class RawPlayerMove
    {
        public string XCoordinate { get; set; }
        public string YCoordinate { get; set; }
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

    class PlayerMove : RawPlayerMove
    {
        private GameState Board { get; set; }
        private int[] Indices { get; set; }

        private Dictionary<int, string> PlayerToSymbolMapping { get; set; } = new Dictionary<int, string>
        {
            {1, "X"},
            {2, "O"}
        };

        public PlayerMove(RawPlayerMove inputtedMove, GameState board)
        {
            XCoordinate = inputtedMove.XCoordinate;
            YCoordinate = inputtedMove.YCoordinate;
            Board = board;
            Indices = ToArrayIndices();
        }

        public bool IsCoordinateValid()
        {
            bool isRowValid = 0 <= Indices[0] && Indices[0] <= 2;
            bool isColValid = 0 <= Indices[1] && Indices[1] <= 2;
            return isRowValid && isColValid;
        }

        public bool IsCoordinateEmptyOnBoard()
        {

            string currentSymbolOnBoard = Board.CurrentBoardState[Indices[0], Indices[1]];
            return (currentSymbolOnBoard == ".");
        }

        public int[] ToArrayIndices()
        {
            int xCoordinateArrayIndex = Convert.ToInt32(XCoordinate) - 1;
            int yCoordinateArrayIndex = Convert.ToInt32(YCoordinate) - 1;
            return new int[] {xCoordinateArrayIndex, yCoordinateArrayIndex};
        }

        public void DrawOnBoard()
        {
            string playerSymbol = PlayerToSymbolMapping[Board.CurrentPlayerTurn];
            Board.CurrentBoardState[Indices[0], Indices[1]] = playerSymbol;
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
