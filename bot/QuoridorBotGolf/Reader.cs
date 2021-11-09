using System;

namespace QuoridorBotGolf
{
    public class Reader : IReader
    {
        public bool ReadFirstMessage(string data)
        {
            return data == "white";
        }

        public void Read(string data)
        {
            var info = data.Split(" ");
            var x = FromLetterToInteger(info[1][0].ToString());
            var y = Int32.Parse(info[1][1].ToString());
            
            if (info[0] == "wall")
            {
                var orientation = info[1][2].ToString() == "v" ? 2 : 1;
                AddWall(x, y, orientation);
            }
            else
            {
                AddOppositeMove(x, y);
            }
        }

        private void AddWall(int x, int y, int orientation)
        {
            Bot.walls[x, y - 1] = orientation;
        }

        private void AddOppositeMove(int x, int y)
        {
            Bot.oppositePlayer.x = x;
            Bot.oppositePlayer.y = y - 1;
        }

        private int FromLetterToInteger(string value)
        {
            return value switch
            {
                "A" => 0,
                "B" => 1,
                "C" => 2,
                "D" => 3,
                "E" => 4,
                "F" => 5,
                "G" => 6,
                "H" => 7,
                "I" => 8,
                _ => -1
            };
        }
    }
}