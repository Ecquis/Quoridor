using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoridorBotGolf
{
    public static class Translator
    {

        static string[] fieldLetters = new string[9] { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
        static string[] wallLetters = new string[8] { "S", "T", "U", "V", "W", "X", "Y", "Z" };
        public static string PointToHuman(Point point, bool isWall)
        {
            if (isWall) { return wallLetters[point.x] + (point.y + 1).ToString(); }
            return fieldLetters[point.x] + (point.y + 1).ToString();
        }

        public static Point HumanToPoint(string move)
        {
            string letter = move[0].ToString();
            int number = int.Parse(move[1].ToString()) - 1;
            int index = Array.IndexOf(fieldLetters, letter);
            if (index == -1) { index = Array.IndexOf(wallLetters, letter); }
            if (index == -1) { return null; }

            return new Point(index, number);
        }
    }
}
