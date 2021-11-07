using System;

namespace QuoridorBotGolf
{
    public static class Bot
    {
        public static Player ourPlayer, oppositePlayer;
        static void Main(string[] args)
        {
            ourPlayer = new Player(5, 0, 8);
            oppositePlayer = new Player(5, 8, 0);
            Console.WriteLine("Hello World!");
        }
    }
}
