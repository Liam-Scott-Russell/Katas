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
    }
}