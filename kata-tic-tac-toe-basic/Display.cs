using System;
using System.Collections.Generic;

namespace kata_tic_tac_toe_basic
{
    static class Display
    {
        public static void ShowBoard(Board currentBoard)
        {
            Display.AlertUser("Here's the current board:");
            foreach (var row in currentBoard.Rows)
            {
                Console.Out.WriteLine(string.Join(" ", row));
            }
        }

        public static string GetPlayersMove(Player player)
        {
            
            var displayMessage = $"Player {player.Number} enter a coord x,y to place your {player.Symbol} or enter 'q' to give up: ";
            AlertUser(displayMessage);
            var playerInput = Console.ReadLine();
            return playerInput;
        }

        public static void AlertUser(string message)
        {
            Console.Out.WriteLine(message);
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static string AskPlayerForMarker(Player player)
        {
            AlertUser($"Please enter the symbol for player {player.Number}.");
            var playerInput = Console.ReadLine();
            return playerInput;
        }

        public static int AskUserForBoardSize()
        {
            AlertUser("Please enter a size for the board from 3 -> 10");
            var suppliedBoardSize = Convert.ToInt32(Console.ReadLine());
            return suppliedBoardSize;
        }

        public static bool AskUserToRepeatGame()
        {
            while (true)
            {
                AlertUser("Do you want to play again? Type Y/N");
                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "Y":
                        return true;
                    case "N":
                        return false;
                    default:
                        continue;
                }
            }
        }

        public static bool AskUserToPlayAgainstBot()
        {
            AlertUser("Do you want to play against a bot? Type Y/N");
            while (true)
            {
                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "Y":
                        return true;
                    case "N":
                        return false;
                    default:
                        continue;
                }
            }
        }
    }
}