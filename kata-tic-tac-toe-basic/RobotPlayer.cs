using System;
using System.Diagnostics;

namespace kata_tic_tac_toe_basic
{
    public class RobotPlayer : Player
    {
        public bool IsIntelligent { get; set; }
        private GameState GameState { get; set; }
        
        public RobotPlayer()
        {
            IsBot = true;
        }

        public Move GenerateMove(GameState currentGameState)
        {
            GameState = currentGameState;
            return IsIntelligent ? GenerateSmartMove() : GenerateRandomMove();
        }

        private Move GenerateRandomMove()
        {
            var randomNumber = new Random();
            while (true)
            {
                int upperBoundForRandomNumber = GameState.CurrentBoard.BoardDimension + 1;
                var xCoordinate = randomNumber.Next(1, upperBoundForRandomNumber);
                var yCoordinate = randomNumber.Next(1, upperBoundForRandomNumber);
                var formattedMove = $"{xCoordinate},{yCoordinate}";
                var possibleMove = new Move(formattedMove, GameState);
                if (possibleMove.IsCoordinatesValid() && possibleMove.IsBoardEmptyAtCoordinates())
                {
                    return possibleMove;
                }
            }
        }

        private Move GenerateSmartMove()
        {
            return GenerateRandomMove();
        }
    }
}