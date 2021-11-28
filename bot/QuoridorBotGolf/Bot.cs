using System;

namespace QuoridorBotGolf
{
    public static class Bot
    {
        public static Player ourPlayer, oppositePlayer;
        public static int[,] walls = new int[8, 8]; // 0 is empty, 1 is horizontal, 2 is vertical
        public static IReader reader = new Reader();
        public static Mover mover = new Mover();
        public static string data = "";
        public static string dataOutput = "";
        static void Main(string[] args)
        {
            data = Console.ReadLine();
            if (reader.ReadFirstMessage(data))
            {
                ourPlayer = new Player(4, 8, 0);
                oppositePlayer = new Player(4, 0, 8);
                dataOutput = mover.MakeMove();
                Console.WriteLine(dataOutput);
            }
            else
            {
                ourPlayer = new Player(4, 0, 8);
                oppositePlayer = new Player(4, 8, 0);
            }

            while (ourPlayer.y != ourPlayer.winPosition || oppositePlayer.y != oppositePlayer.winPosition)
            {
                data = Console.ReadLine();
                reader.Read(data);
                dataOutput = mover.MakeMove();
                Console.WriteLine(dataOutput);
            }
        }
    }
}
