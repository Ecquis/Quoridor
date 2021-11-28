using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoridorBotGolf
{
    public class Waver
    {
        public static int[,] field = new int[9,9];
        public static Way FindWinWay(Player player)
        {

            Way way;
            Point userPosition = player.GetPosition();
            int winPosition = player.winPosition;

            int markNumber = 1, x, y;
            bool isFinished = false;

            field[userPosition.x, userPosition.y] = 1;

            while (!isFinished)
            {
                for (y = 0; y < 9; y++)
                    for (x = 0; x < 9; x++)
                    {
                        if (field[x, y] == markNumber)
                        {
//                            ShowField();
                           

                            if (y - 1 >= 0 && field[x, y - 1] == 0 && CheckWall(x, y - 1, x, y))
                            {
                                field[x, y - 1] = markNumber + 1;
                                if (y - 1 == winPosition)
                                {
                                    isFinished = true;
                                    break;
                                }
                            }
                            if (x - 1 >= 0 && field[x - 1, y] == 0 && CheckWall(x - 1, y, x, y))
                            {
                                field[x - 1, y] = markNumber + 1;
                            }

                            if (y + 1 < 9 && field[x, y + 1] == 0 && CheckWall(x, y + 1, x, y))
                            {
                                field[x, y + 1] = markNumber + 1;
                                if (y + 1 == winPosition)
                                {
                                    isFinished = true;
                                    break;
                                }
                            }
                            if (x + 1 < 9 && field[x + 1, y] == 0 && CheckWall(x + 1, y, x, y))
                            {
                                field[x + 1, y] = markNumber + 1;
                            }
                        }

                    }
                markNumber++;
            }

           //ShowField();

            way = RecoverWay(winPosition, markNumber);
            return way;
        }

        private static bool CheckWall(int x, int y, int originX, int originY)
		{
            int wallType = 0, wallX = -1, wallY = -1;
            if(x > originX || y > originY)
			{
                wallX = x == 0 ? 0 : x - 1;
                wallY = y == 0 ? 0 : y - 1;
            }
            if (x < originX || y < originY)
            {
                wallX = originX == 0 ? 0 : originX - 1;
                wallY = originY == 0 ? 0 : originY - 1;
            }

            if(wallX >= 0 && wallY >= 0)
			{
                wallType = Bot.walls[wallX, wallY];
            }

            if(wallType == 0)
			{
                if((x > originX || y > originY) && originX < 8 && originY < 8)
				{
                    wallX = originX;
                    wallY = originY;
				}
                if((x < originX || y < originY) && y < 8 && x < 8)
				{
                    wallX = x;
                    wallY = y;
				}


                wallType = Bot.walls[wallX, wallY];
            }


            if (x != originX)
			{
                return wallType != 2;
			}

            if(y != originY)
			{
                return wallType != 1;
			}

            return true;
		}

        private static Way RecoverWay(int winPosition, int markNumber)
		{
            Way way = new Way();
            int step = markNumber;
            Point point = new Point(0, 0);

            for (int y = 0; y < 9; y++)
                for (int x = 0; x < 9; x++)
				{
                    if (field[x, y] == step && y == winPosition)
                        point = new Point(x, y);
                }

            step--;
                    
            while (step != 1)
            {
                if (point.y - 1 >= 0 && field[point.x, point.y - 1] == step)
                {
                    point = new Point(point.x, point.y - 1);
                    way.AddPoint(point);
                }
                else if (point.x - 1 >= 0 && field[point.x - 1, point.y] == step)
                {
                    point = new Point(point.x - 1, point.y);
                    way.AddPoint(point);
                }
                else if (point.y + 1 < 9 && field[point.x, point.y + 1] == step)
                {
                    point = new Point(point.x, point.y + 1);
                    way.AddPoint(point);
                }
                else if (point.x + 1 < 9 && field[point.x + 1, point.y] == step)
                {
                    point = new Point(point.x, point.y - 1);
                    way.AddPoint(point);
                }
                step--;
            }
            way.Reverse();

            return way;
		}
        static void ShowField()
        {
            Console.WriteLine("--------Field---------");
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    Console.Write(field[x, y]);
                    if (x == 8)
                    {
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine("------------------");
        }
    }
}
