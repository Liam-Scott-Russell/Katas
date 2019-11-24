using System;
using System.Collections.Generic;

namespace kata_tic_tac_toe_basic
{
    public class Display
    {
        static void ShowBoard(Board currentBoard)
        {
            foreach (var row in currentBoard.Rows)
            {
                Console.Out.WriteLine(string.Join(" ", row));
            }
        }

        static string GetPlayersMove(Player player)
        {
            
            var displayMessage = $"Player {player.Number} enter a coord x,y to place your {player.Symbol} or enter 'q' to give up: ";
            Alert(displayMessage);
            var playerInput = Console.ReadLine();
            return playerInput;
        }

        static void Alert(string message)
        {
            Console.Out.WriteLine(message);
        }
    }
}