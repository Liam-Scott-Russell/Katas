using System;

namespace Game_Of_Life
{
    public class Display
    {
        public static void ShowBoard(Board board)
        {
            for (int i = 0; i < board.Height; i++)
            {
                for (int j = 0; j < board.Width; j++)
                {
                    if (board.Cells[i, j].IsLiving)
                    {
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    
                }
                
                Console.Write(Environment.NewLine);
            }
        }

        public static void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static string AskUserForBoardSize()
        {
            AlertUser("Please enter a board size with the format <width>,<height>");
            return Console.ReadLine();
        }
    }
}