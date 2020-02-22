using System;

namespace Game_Of_Life
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new GameController();
            game.PlayGame();
        }
    }
}