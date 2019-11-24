using System;
using System.Collections.Generic;

namespace kata_tic_tac_toe_basic
{
    class GameController
    {
        private GameState Game { get; set; } = new GameState();
        private Dictionary<int, string> PlayerToSymbolMapping { get; set; } = new Dictionary<int, string>
        {
            {1, "X"},
            {2, "O"}
        };

        public GameController()
        {
            string[,] blankBoard = new string[,] {{".", ".", "."}, {".", ".", "."}, {".", ".", "."}};
            Game.CurrentBoardState = blankBoard;
            Game.CurrentPlayerTurn = 1;
            Game.TurnsPlayed = 0;
        }
        public void PlayGame()
        {
            PrintCurrentBoard();
            while (true)
            {
                string userInput = GetInput();
                if (userInput == "q")
                {
                    break;
                }

                string[] splitUserInput = userInput.Split(",");
                PlayerMove move = new PlayerMove(new RawPlayerMove() 
                    {XCoordinate = splitUserInput[0], YCoordinate = splitUserInput[1]}, Game);
                
                if (move.IsCoordinateValid() && move.IsCoordinateEmptyOnBoard())
                {
                    move.DrawOnBoard();
                    
                    switch (Game.CurrentPlayerTurn)
                    {
                        case 1:
                            Game.CurrentPlayerTurn = 2;
                            break;
                        case 2:
                            Game.CurrentPlayerTurn = 1;
                            break;
                    }
                    Console.Clear();
                    Console.Out.WriteLine("Move accepted!");
                    PrintCurrentBoard();
                }

            }
        }

        public string GetInput()
        {
            Console.Out.WriteLine($"Player {Game.CurrentPlayerTurn} enter a coord x,y to place your {PlayerToSymbolMapping[Game.CurrentPlayerTurn]} or enter 'q' to give up:");
            return Console.ReadLine();
        }

        public void PrintCurrentBoard()
        {
            Console.Out.WriteLine("Here's the current board:");
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