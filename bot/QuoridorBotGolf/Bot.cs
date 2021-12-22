using System;

namespace QuoridorBotGolf
{
    public static class Bot
    {
        public static Player ourPlayer, oppositePlayer;
        public static int[,] walls = new int[8, 8]; // 0 is empty, 1 is horizontal, 2 is vertical
        public static string dataOutput = "";
        static void Main(string[] args)
        {
            string firstMessage = Console.ReadLine();
            if (Reader.IsFirstMove(firstMessage))
            {
                ourPlayer = new Player(4, 8, 0);
                oppositePlayer = new Player(4, 0, 8);
                Command command = Mover.MakeMove();
                PrintMove(command);
            }
            else
            {
                ourPlayer = new Player(4, 0, 8);
                oppositePlayer = new Player(4, 8, 0);
            }

            while (true)
            {
                string message = Console.ReadLine();
                Command command = Reader.ParseCommand(message);
                ExecCommand(command);

                command = Mover.MakeMove();
                PrintMove(command);
                //ShowField();
            }
        }


        // 1 - v, 2 - h
        static void ExecCommand(Command command)
        {
            if (command.word == "wall")
            {
                walls[command.point.x, command.point.y] = command.type == "v" ? 1 : 2;
            }
            else
            {
                oppositePlayer.SetPosition(command.point);
            }
        }
        static void PrintMove(Command command)
        {
            //Console.WriteLine("x {0} y {1}", command.point.x, command.point.y);
            string humanPoint = Translator.PointToHuman(command.point, command.type != null);
            Console.WriteLine("{0} {1}{2}", command.word, humanPoint, command.type);
        }

        static void ShowField()
        {
            string[,] strs = new string[17, 17];
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (x < 8 && y < 8)
                    {
                        if (walls[x, y] == 1)
                        {
                            strs[2 * x + 1, 2 * y + 1] = "v";
                            strs[2 * x + 1, 2 * y] = "v";
                            strs[2 * x + 1, 2 * y+2] = "v";
                        }
                        if (walls[x, y] == 2)
                        {
                            strs[2 * x + 1, 2*y+1] = "h";
                            strs[2 * x, 2 * y + 1] = "h";
                            strs[2 * x + 2, 2 * y + 1] = "h";
                        }
                    }

                    if (ourPlayer.x == x && ourPlayer.y == y)
                    {
                        strs[2*x, 2*y] = "p";
                    } else if (oppositePlayer.x == x && oppositePlayer.y == y)
                    {
                        strs[2*x, 2*y] = "r";
                    }
                }
            }
            Console.WriteLine("--------Field---------");
            for (int y = 0; y < 17; y ++)
            {
                for (int x = 0; x < 17; x ++)
                {
                    if ((x % 2 == 1 || y % 2 == 1) && strs[x, y] == null)
                    {
                        Console.Write(".");
                    } else if (strs[x, y] == null)
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
