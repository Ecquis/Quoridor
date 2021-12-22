using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoridorBotGolf
{
    public class Command
    {
        public string word;
        public Point point;
        public string type = null;

        public Command(string word, Point point, string type)
        {
            this.word = word;
            this.point = point;
            this.type = type;
        }

        public Command(string word, Point point)
        {
            this.word = word;
            this.point = point;
        }

        public Command()
        {
        }
    }
}
