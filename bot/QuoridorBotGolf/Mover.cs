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
            // calculate distance to the nearest win position
            Way ourWay = Waver.FindWinWay(Bot.ourPlayer);
            int ourDistance = ourWay.GetLength();
            // calculate distance for opposite player to the NWP

            return null;
        }
    }
}
