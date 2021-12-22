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
        public int wallsSet = 0;

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

        public Point GetPosition()
		{
            return new Point(this.x, this.y);
		}

        public int GetWallsSet()
        {
            return wallsSet;
        }

        public void IncWallsSet()
        {
            wallsSet++;
        }
    }
}
