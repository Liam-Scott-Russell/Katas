using System;
using System.Text.RegularExpressions;

namespace Game_Of_Life
{
    public class GameController
    {
        public Board CurrentBoard { get; set; }

        public void PlayGame()
        {
            Display.AlertUser("Welcome to Game of Life!!");
            SetupGame();
            GameLoop();
        }

        private void GameLoop()
        {
            while (true)
            {
                Display.ShowBoard(CurrentBoard);
                CurrentBoard.UpdateCells();
                Console.ReadLine();
            }
        }

        private void SetupGame()
        {
            string userSuppliedBoardSize;
            while (true)
            {
                userSuppliedBoardSize = Display.AskUserForBoardSize();
                if (IsBoardSizeValidFormat(userSuppliedBoardSize))
                {
                    break;
                }
            }

            var dimensions = GetSeparatedBoardSize(userSuppliedBoardSize);
            
            CurrentBoard = new Board(dimensions[0], dimensions[1]);
            CurrentBoard.RandomlyAssignCellStates();
            CurrentBoard.CalculateCellNeighbours();
        }

        private bool IsBoardSizeValidFormat(string possibleSize)
        {
            var inputFormatRegex = new Regex(@"^(\d+,\d+)$");
            var matches = inputFormatRegex.Matches(possibleSize);
            return matches.Count == 1;
        }

        private int[] GetSeparatedBoardSize(string userSuppliedBoardSize)
        {
            var separated = userSuppliedBoardSize.Split(",");
            var dimensions = new int[2]
            {
                Convert.ToInt32(separated[0]),
                Convert.ToInt32(separated[1])
            };
            return dimensions;
        }
    }
}