using System;

namespace QuoridorBotGolf
{
    public static class Bot
    {
        public static Player ourPlayer, oppositePlayer;
        public static int[,] walls = new int[8, 8]; // 0 is empty, 1 is horizontal, 2 is vertical
        static void Main(string[] args)
        {
            ourPlayer = new Player(5, 0, 8);
            oppositePlayer = new Player(5, 8, 0);
            Console.WriteLine("Hello World!");
        }
    }
}
