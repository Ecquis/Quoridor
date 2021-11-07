using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoridorBotGolf
{
    public class Waver
    {
        public static Way FindWinWay(Player player)
        {
            Way way = new Way();
            way.AddPoint(new Point(5, 6));
            return way;
        }
    }
}
