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
    }
}