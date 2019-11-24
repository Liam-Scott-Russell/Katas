using System;

namespace kata_tic_tac_toe_basic
{
    class GameController
    {
        private GameState GameState { get; set; }

        public GameController()
        {
            var gameBoard = new Board();
            var player1 = new Player()
            {
                Number = 1,
                Symbol = "X",
            };
            var player2 = new Player()
            {
                Number = 2,
                Symbol = "O"
            };
            GameState = new GameState()
            {
                CurrentBoard = gameBoard,
                CurrentPlayer = player1,
                AllPlayers = new Player[2]
                {
                    player1,
                    player2
                }
            };
        }

        private Player GetNonActivePlayer()
        {
            var targetIndex = 2 - GameState.CurrentPlayer.Number;
            return GameState.AllPlayers[targetIndex];
        }

        public void PlayGame()
        {
            Display.AlertUser("Welcome to Tic Tac Toe!");
            while (true)
            {
                Display.ShowBoard(GameState.CurrentBoard);

                var userInput = Display.GetPlayersMove(GameState.CurrentPlayer);
                if (userInput == "q") { break; }
                Move userMove = new Move(userInput, GameState);
                
                if (!userMove.IsValid())
                {
                    Display.ClearScreen();
                    Display.AlertUser("Sorry, that move is invalid, please try again ...");
                    continue;
                }
                userMove.MakeMove();
                
                if (WinConditions.IsGameDraw(GameState.CurrentBoard))
                {
                    Display.AlertUser("The game is draw, no-one wins!");
                    Display.ShowBoard(GameState.CurrentBoard);
                    break;
                }
                
                if (WinConditions.PlayerHasWon(GameState.CurrentBoard, GameState.CurrentPlayer))
                {
                    Display.AlertUser("You have won, congratulations!");
                    Display.ShowBoard(GameState.CurrentBoard);
                    break;
                }

                GameState.CurrentPlayer = GetNonActivePlayer();
                Display.ClearScreen();
            }
                
        }

        private void GameLoop()
        {
            
        }
    }
}