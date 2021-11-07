using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoridorBotGolf
{
    public class Player : Point
    {
        public int winPosition;

        public Player(int x, int y, int winPosition): base(x, y) {
            this.x = x;
            this.y = y;
            this.winPosition = winPosition;
        }

        public void SetPosition(Point point)
        {
            this.x = point.x;
            this.y = point.y;
        }
    }
}
