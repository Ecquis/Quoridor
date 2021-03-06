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
        
        public void Reverse()
        {
            points.Reverse();
        }

        public Point GetFirstPoint()
        {
            if (points.Count == 0) { return null; }

            return points[0];
        }

        public Point GetPoint(int index)
        {
            if (index >= GetLength()) { return null; }
            return points[index];
        }

        public void AddPoint(Point point)
        {
            points.Add(point);
        }

        public void RemoveLastPoint()
        {
            points.RemoveAt(points.Count - 1);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < points.Count; i++)
            {
                str.Append(points[i].x + " " + points[i].y + "-> ");
            }
            str.Append("\n");
            return str.ToString();
        }

    }
}
