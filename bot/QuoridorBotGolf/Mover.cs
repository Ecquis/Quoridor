using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoridorBotGolf
{
    public class Mover
    {
        public static Command MakeMove()
        {
            Way ourWay = Waver.FindWinWay(Bot.ourPlayer);
            int ourDistance = ourWay.GetLength();

            Way oppositeWay = Waver.FindWinWay(Bot.oppositePlayer);
            if (oppositeWay == null)
            {
                Point nextPoint = ourWay.GetFirstPoint();
                return Move(nextPoint);
            }
            int oppositeDistance = oppositeWay.GetLength();
            //Console.WriteLine("dist: " + ourDistance + " " + oppositeDistance);
            if (ourDistance <= oppositeDistance)
            {
                Point nextPoint = ourWay.GetFirstPoint();
                return Move(nextPoint);
            }

            Command command = null;
            if (Bot.ourPlayer.GetWallsSet() < 10)
            {
                command = TryToSetWall(oppositeWay);
            }
            if (command == null)
            {
                Point nextPoint = ourWay.GetFirstPoint();
                return Move(nextPoint);
            }
            Bot.ourPlayer.IncWallsSet();
            return command;
        }

        private static Command Move(Point point)
        {
            string word = "move";
            if (Math.Abs(Bot.ourPlayer.x - point.x) > 1 || Math.Abs(Bot.ourPlayer.y - point.y) > 1)
            {
                word = "jump";                
            }
            Bot.ourPlayer.SetPosition(point);
            return new Command(word, point);
        }

        private static Command TryToSetWall(Way way)
        {
            for (int i = 0; i < way.GetLength(); i ++)
            {
                Point currentPoint = way.GetPoint(i);

                if (currentPoint.y - Bot.oppositePlayer.y > 0)
                {
                    Point w1point = new Point(currentPoint.x - 1, currentPoint.y - 1);
                    if (IsWallSetAt(w1point)) { continue; }
                    Point w2point = new Point(currentPoint.x, currentPoint.y - 1);
                    if (IsWallSetAt(w2point)) { continue; }

                    Point wallPoint = new Point(currentPoint.x - 1, currentPoint.y - 1);
                    if (IsInbound(wallPoint.x, wallPoint.y) && CanWallBeSet(wallPoint, 2))
                    {
                        Bot.walls[wallPoint.x, wallPoint.y] = 2;
                        return new Command("wall", wallPoint, "h");
                    }

                    wallPoint = new Point(currentPoint.x, currentPoint.y - 1);
                    if (IsInbound(wallPoint.x, wallPoint.y) && CanWallBeSet(wallPoint, 2))
                    {
                        Bot.walls[wallPoint.x, wallPoint.y] = 2;
                        return new Command("wall", wallPoint, "h");
                    }
                }

                if (currentPoint.y - Bot.oppositePlayer.y < 0)
                {
                    Point w1point = new Point(currentPoint.x - 1, currentPoint.y);
                    if (IsWallSetAt(w1point)) { continue; }
                    Point w2point = new Point(currentPoint.x, currentPoint.y);
                    if (IsWallSetAt(w2point)) { continue; }

                    Point wallPoint = new Point(currentPoint.x - 1, currentPoint.y);
                    if (IsInbound(wallPoint.x, wallPoint.y) && CanWallBeSet(wallPoint, 2))
                    {
                        Bot.walls[wallPoint.x, wallPoint.y] = 2;
                        return new Command("wall", wallPoint, "h");
                    }

                    wallPoint = new Point(currentPoint.x, currentPoint.y);
                    if (IsInbound(wallPoint.x, wallPoint.y) && CanWallBeSet(wallPoint, 2))
                    {
                        Bot.walls[wallPoint.x, wallPoint.y] = 2;
                        return new Command("wall", wallPoint, "h");
                    }
                }

                if (currentPoint.x - Bot.oppositePlayer.x > 0)
                {
                    Point w1point = new Point(currentPoint.x, currentPoint.y - 1);
                    if (IsWallSetAt(w1point)) { continue; }
                    Point w2point = currentPoint;
                    if (IsWallSetAt(w2point)) { continue; }

                    Point wallPoint = new Point(currentPoint.x, currentPoint.y - 1);
                    if (IsInbound(wallPoint.x, wallPoint.y) && CanWallBeSet(wallPoint, 1)) {
                        Bot.walls[wallPoint.x, wallPoint.y] = 1;
                        return new Command("wall", wallPoint, "v");
                    }

                    wallPoint = new Point(currentPoint.x, currentPoint.y);
                    if (IsInbound(wallPoint.x, wallPoint.y) && CanWallBeSet(wallPoint, 1)) {
                        Bot.walls[wallPoint.x, wallPoint.y] = 1;
                        return new Command("wall", wallPoint, "v"); 
                    }
                }
                if (currentPoint.x - Bot.oppositePlayer.x < 0)
                {
                    Point w1point = new Point(currentPoint.x - 1, currentPoint.y - 1);
                    if (IsWallSetAt(w1point)) { continue; }
                    Point w2point = new Point(currentPoint.x - 1, currentPoint.y);
                    if (IsWallSetAt(w2point)) { continue; }

                    Point wallPoint = new Point(currentPoint.x - 1, currentPoint.y - 1);
                    if (IsInbound(wallPoint.x, wallPoint.y) && CanWallBeSet(wallPoint, 1)) {
                        Bot.walls[wallPoint.x, wallPoint.y] = 1;
                        return new Command("wall", wallPoint, "v"); 
                    }

                    wallPoint = new Point(currentPoint.x - 1, currentPoint.y);
                    if (IsInbound(wallPoint.x, wallPoint.y) && CanWallBeSet(wallPoint, 1)) {
                        Bot.walls[wallPoint.x, wallPoint.y] = 1;
                        return new Command("wall", wallPoint, "v"); 
                    }
                }
            }
            return null;
        }

        private static bool IsInbound(int x, int y)
        {
            return !(x < 0 || x > 7 || y < 0 || y > 7);
        }

        private static bool CanWallBeSet(Point point, int wallType)
        {
            Bot.walls[point.x, point.y] = wallType;
            Way ourWay = Waver.FindWinWay(Bot.ourPlayer);
            if (ourWay == null) { return false; }
            int ourDistance = ourWay.GetLength();

            Way oppositeWay = Waver.FindWinWay(Bot.oppositePlayer);
            if (oppositeWay == null) { return false; }
            int oppositeDistance = oppositeWay.GetLength();
            Bot.walls[point.x, point.y] = 0;
            if (ourDistance == 0 || oppositeDistance == 0) {
                return false;
            };

            if (wallType == 1 && (IsInbound(point.x, point.y - 1) && Bot.walls[point.x, point.y - 1] == 1 || IsInbound(point.x, point.y + 1) && Bot.walls[point.x, point.y + 1] == 1)) // v
            {
                return false;
            }

            if (wallType == 2 && (IsInbound(point.x - 1, point.y) && Bot.walls[point.x - 1, point.y] == 2 || IsInbound(point.x + 1, point.y) && Bot.walls[point.x + 1, point.y] == 2)) // h
            {
                return false;
            }

            return true;

        }

        private static bool IsWallSetAt(Point point)
        {
            return IsInbound(point.x, point.y) && Bot.walls[point.x, point.y] != 0;
        }
        
    }
}
