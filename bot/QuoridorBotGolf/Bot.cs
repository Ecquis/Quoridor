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
                if (dataOutput.Length == 3)
                {
                    dataOutput = "wall " + dataOutput;
                }
                else
                {
                    dataOutput = "move " + dataOutput;
                }
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
                //ShowField();
                if (dataOutput.Length == 3)
                {
                    dataOutput = "wall " + dataOutput;
                } else
                {
                    dataOutput = "move " + dataOutput;
                }
                Console.WriteLine(dataOutput);
            }
        }
        static void ShowField()
        {
            string[,] strs = new string[9, 9];
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (x < 8 && y < 8)
                    {
                        if (walls[x, y] == 1)
                        {
                            strs[x, y] = "v";
                            strs[x, y - 1] = "v";
                            strs[x, y + 1] = "v";
                        }
                        if (walls[x, y] == 2)
                        {
                            strs[x, y] = "h";
                            strs[x - 1, y] = "h";
                            strs[x + 1, y] = "h";
                        }
                    }

                    if (ourPlayer.x == x && ourPlayer.y == y)
                    {
                        strs[x, y] = "p";
                    } else if (oppositePlayer.x == x && oppositePlayer.y == y)
                    {
                        strs[x, y] = "r";
                    }
                }
            }
            Console.WriteLine("--------Field---------");
            for (int y = 0; y < 9; y ++)
            {
                for (int x = 0; x < 9; x ++)
                {
                    if (strs[x, y] == null)
                    {
                        Console.Write("o");
                    } else
                    {
                        Console.Write(strs[x,y]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------");
        }
    }
}
