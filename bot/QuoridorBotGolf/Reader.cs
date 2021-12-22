using System;

namespace QuoridorBotGolf
{
    class Reader
    {

        public static bool IsFirstMove(string order)
        {
            return order.ToLower() == "white";
        }

        public static Command ParseCommand(string command)
        {
            string[] words = command.Split();
            string firstWord = words[0].Trim().ToLower();
            Point point = readPoint(words[1]);
            string type = null;
            if (firstWord == "wall")
            {
                type = words[1][2].ToString().ToLower();
            }
            return new Command(firstWord, point, type);
        }

        static Point readPoint(string pointStr)
        {
            int x = fromLetterToInteger(pointStr[0]);
            int y = int.Parse(pointStr[1].ToString()) - 1;
            return new Point(x, y);
        }

        static int fromLetterToInteger(char value)
        {
            return value switch
            {
                'A' => 0,
                'B' => 1,
                'C' => 2,
                'D' => 3,
                'E' => 4,
                'F' => 5,
                'G' => 6,
                'H' => 7,
                'I' => 8,
                'S' => 0,
                'T' => 1,
                'U' => 2,
                'V' => 3,
                'W' => 4,
                'X' => 5,
                'Y' => 6,
                'Z' => 7,
                _ => -1
            };
        }

    }
}