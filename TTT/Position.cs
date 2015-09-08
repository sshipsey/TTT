using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT
{
    public class Position
    {
        public bool occupied { get; set; }

        public char marker { get; set; }

        public int x { get; set; }

        public int y { get; set; }

        public Position(int xpos, int ypos)
        {
            occupied = false;
            marker = ' ';
            x = xpos;
            y = ypos;
        }

        public void Mark(int team)
        {
            occupied = true;
            marker = team == 0 ? 'X' : 'O';
        }
    }
}
