using System;

namespace kata_tic_tac_toe_basic
{
    class GameController
    {
        private GameState GameState { get; set; }

        public GameController()
        {
            // Set to 3 by default, but is overwritten later by the user.
            Board gameBoard = new Board(3);
            
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

        private void SetupGame()
        {
            Display.ClearScreen();
            Display.AlertUser("Welcome to Tic Tac Toe!");

            var userSuppliedBoardSize = Display.AskUserForBoardSize();
            GameState.CurrentBoard = new Board(userSuppliedBoardSize);
            
            GameState.AllPlayers[0].Symbol = Display.AskPlayerForMarker(GameState.AllPlayers[0]);
            GameState.AllPlayers[1].Symbol = Display.AskPlayerForMarker(GameState.AllPlayers[1]);
        }

        private void SetupBot()
        {
            bool userWantsToPlayBot = Display.AskUserToPlayAgainstBot();
            if (userWantsToPlayBot)
            {
                GameState.AllPlayers[1] = new RobotPlayer()
                {
                    IsIntelligent = false,
                    Number = 2,
                    Symbol = "O"
                };
            }
        }

        public void PlayGame()
        {
            SetupBot();
            SetupGame();
            
            while (true)
            {
                Display.ShowBoard(GameState.CurrentBoard);
                
                Move userMove;

                if (GameState.CurrentPlayer.IsBot)
                {
                    RobotPlayer bot = (RobotPlayer) GameState.CurrentPlayer;
                    userMove = bot.GenerateMove(GameState);
                }
                else
                {
                    var userInput = Display.GetPlayersMove(GameState.CurrentPlayer);
                    if (userInput == "q") { break; }
                    
                    if (Move.IsMatchForMoveInputFormat(userInput))
                    {
                        userMove = new Move(userInput, GameState);
                    }
                    else
                    {
                        Display.ClearScreen();
                        Display.AlertUser("Sorry, that move is invalid, please try again ...");
                        Display.AlertUser("The format for a move is <x-coordinate>,<y-coordinate>");
                        Display.AlertUser("The top left corner has a coordinate of (1,1)");
                        continue;
                    }
                }
                
                
                if (userMove.IsCoordinatesValid() && userMove.IsBoardEmptyAtCoordinates())
                {
                    userMove.MakeMove();
                }
                else
                {
                    Display.ClearScreen();
                    Display.AlertUser("Sorry, that move is invalid, please try again ...");
                    continue;
                }

                if (WinConditions.IsGameDraw(GameState.CurrentBoard))
                {
                    Display.AlertUser("The game is draw, no-one wins!");
                    Display.ShowBoard(GameState.CurrentBoard);
                    
                    if (Display.AskUserToRepeatGame())
                    {
                        SetupGame();
                        continue;
                    }
                    break;
                }
                
                if (WinConditions.PlayerHasWon(GameState.CurrentBoard, GameState.CurrentPlayer))
                {
                    Display.AlertUser($"Player {GameState.CurrentPlayer.Number} wins, congratulations!");
                    Display.ShowBoard(GameState.CurrentBoard);
                    
                    if (Display.AskUserToRepeatGame())
                    {
                        SetupGame();
                        continue;
                    }
                    break;
                }

                GameState.CurrentPlayer = GetNonActivePlayer();
                Display.ClearScreen();
            }
        }
    }
}