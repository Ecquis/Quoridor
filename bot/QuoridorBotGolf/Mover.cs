﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoridorBotGolf
{
    public class Mover
    {
        public string MakeMove()
        {
            Way ourWay = Waver.FindWinWay(Bot.ourPlayer);
            int ourDistance = ourWay.GetLength();

            Way oppositeWay = Waver.FindWinWay(Bot.oppositePlayer);
            int oppositeDistance = oppositeWay.GetLength();   

            if (ourDistance <= oppositeDistance)
            {
                Point nextPoint = ourWay.GetFirstPoint();
                return Move(nextPoint);
            }
            string move = TryToSetWall(oppositeWay);
            if (move == null)
            {
                Point nextPoint = ourWay.GetFirstPoint();
                return Move(nextPoint);
            }
            return move;
        }

        private static string Move(Point point)
        {
            Bot.ourPlayer.SetPosition(point);
            return Translator.PointToHuman(point, false);
        }

        private static string TryToSetWall(Way way)
        {
            for (int i = 0; i < way.GetLength(); i ++)
            {
                Point currentPoint = way.GetPoint(i);
                if (currentPoint.x - Bot.oppositePlayer.x > 0)
                {
                    Point w1point = new Point(currentPoint.x, currentPoint.y - 1);
                    if (IsWallSetAt(w1point, 1)) { continue; }
                    Point w2point = currentPoint;
                    if (IsWallSetAt(w2point, 1)) { continue; }

                    Point wallPoint = new Point(currentPoint.x, currentPoint.y - 1);
                    if (CanWallBeSet(wallPoint, 1)) {
                        Bot.walls[wallPoint.x, wallPoint.y] = 1;
                        return Translator.PointToHuman(wallPoint, true) + "v"; 
                    }

                    wallPoint = new Point(currentPoint.x, currentPoint.y);
                    if (CanWallBeSet(wallPoint, 1)) {
                        Bot.walls[wallPoint.x, wallPoint.y] = 1;
                        return Translator.PointToHuman(wallPoint, true) + "v"; 
                    }
                }
                if (currentPoint.x - Bot.oppositePlayer.x < 0)
                {
                    Point w1point = new Point(currentPoint.x - 1, currentPoint.y - 1);
                    if (IsWallSetAt(w1point, 1)) { continue; }
                    Point w2point = new Point(currentPoint.x - 1, currentPoint.y);
                    if (IsWallSetAt(w2point, 1)) { continue; }

                    Point wallPoint = new Point(currentPoint.x - 1, currentPoint.y - 1);
                    if (CanWallBeSet(wallPoint, 1)) {
                        Bot.walls[wallPoint.x, wallPoint.y] = 1;
                        return Translator.PointToHuman(wallPoint, true) + "v"; 
                    }

                    wallPoint = new Point(currentPoint.x - 1, currentPoint.y);
                    if (CanWallBeSet(wallPoint, 1)) {
                        Bot.walls[wallPoint.x, wallPoint.y] = 1;
                        return Translator.PointToHuman(wallPoint, true) + "v"; 
                    }
                }

                if (currentPoint.y - Bot.oppositePlayer.y > 0)
                {
                    Point w1point = new Point(currentPoint.x - 1, currentPoint.y - 1);
                    if (IsWallSetAt(w1point, 2)) { continue; }
                    Point w2point = new Point(currentPoint.x, currentPoint.y - 1);
                    if (IsWallSetAt(w2point, 2)) { continue; }

                    Point wallPoint = new Point(currentPoint.x - 1, currentPoint.y - 1);
                    if (CanWallBeSet(wallPoint, 2)) {
                        Bot.walls[wallPoint.x, wallPoint.y] = 2;
                        return Translator.PointToHuman(wallPoint, true) + "h"; 
                    }

                    wallPoint = new Point(currentPoint.x, currentPoint.y - 1);
                    if (CanWallBeSet(wallPoint, 2)) {
                        Bot.walls[wallPoint.x, wallPoint.y] = 2;
                        return Translator.PointToHuman(wallPoint, true) + "h"; 
                    }
                }

                if (currentPoint.y - Bot.oppositePlayer.y < 0)
                {
                    Point w1point = new Point(currentPoint.x - 1, currentPoint.y);
                    if (IsWallSetAt(w1point, 2)) { continue; }
                    Point w2point = new Point(currentPoint.x, currentPoint.y);
                    if (IsWallSetAt(w2point, 2)) { continue; }

                    Point wallPoint = new Point(currentPoint.x - 1, currentPoint.y);
                    if (CanWallBeSet(wallPoint, 2)) {
                        Bot.walls[wallPoint.x, wallPoint.y] = 2;
                        return Translator.PointToHuman(wallPoint, true) + "h"; 
                    }

                    wallPoint = new Point(currentPoint.x, currentPoint.y);
                    if (CanWallBeSet(wallPoint, 2)) {
                        Bot.walls[wallPoint.x, wallPoint.y] = 2;
                        return Translator.PointToHuman(wallPoint, true) + "h"; 
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
            int ourDistance = ourWay.GetLength();

            Way oppositeWay = Waver.FindWinWay(Bot.oppositePlayer);
            int oppositeDistance = oppositeWay.GetLength();
            Bot.walls[point.x, point.y] = 0;
            if (ourDistance == 0 || oppositeDistance == 0) {
                return false;
            };

            if (wallType == 1 && (IsInbound(point.x, point.y - 1) && Bot.walls[point.x, point.y - 1] == 1 || IsInbound(point.x, point.y + 1) && Bot.walls[point.x, point.y + 1] == 1)) // v
            {
                return false;
            }

            if (wallType == 2 && (IsInbound(point.x - 1, point.y) && Bot.walls[point.x - 1, point.y] == 2 || IsInbound(point.x + 2, point.y) && Bot.walls[point.x + 2, point.y] == 2)) // h
            {
                return false;
            }

            return true;

        }

        private static bool IsWallSetAt(Point point, int wallType)
        {
            return IsInbound(point.x, point.y) && Bot.walls[point.x, point.y] == wallType;
        }
        
    }
}
