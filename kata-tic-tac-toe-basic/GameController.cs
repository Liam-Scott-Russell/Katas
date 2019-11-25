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
            };
            var player2 = new Player()
            {
                Number = 2,
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

            GameState.AllPlayers[0].Symbol = Display.AskPlayerForMarker(GameState.AllPlayers[0]);
            GameState.AllPlayers[1].Symbol = Display.AskPlayerForMarker(GameState.AllPlayers[1]);
            
            while (true)
            {
                Display.ShowBoard(GameState.CurrentBoard);

                var userInput = Display.GetPlayersMove(GameState.CurrentPlayer);
                if (userInput == "q") { break; }
                var userMove = new Move(userInput, GameState);
                
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
    }
}