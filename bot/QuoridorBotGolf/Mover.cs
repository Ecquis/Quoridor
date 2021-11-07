using System;
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

            if (ourDistance < oppositeDistance)
            {
                Point nextPoint = ourWay.GetFirstPoint();
                return Mover.Move(nextPoint);
            } else
            {
                // set wall
            }
            return null;
        }

        public static string Move(Point point)
        {
            Bot.ourPlayer.SetPosition(point);
            return Translator.PointToHuman(point);
        }
    }
}
