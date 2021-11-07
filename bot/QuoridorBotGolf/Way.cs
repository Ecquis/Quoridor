using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoridorBotGolf
{
    public class Way
    {
        public List<Point> points;

        public Way()
        {
            points = new List<Point>();
        }
        public List<Point> GetWay()
        {
            return points;
        }

        public int GetLength()
        {
            return points.Count;
        }

        public void AddPoint(Point point)
        {
            points.Append(point);
        }

        public void RemoveLastPoint()
        {
            points.RemoveAt(points.Count - 1);
        }

    }
}
