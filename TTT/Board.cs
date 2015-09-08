using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT
{
    public class Board
    {
        public Position[] state { get; set; }

        public Board()
        {
            state = new Position[9];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state[3 * i + j] = new Position(i, j);
                }
            }
        }

        public override string ToString()
        {
            string s = "\n\n\n";
            s += "          " + state[0].marker + " | " + state[1].marker + " | " + state[2].marker + "\n";
            s += "          " + "-----------\n";
            s += "          " + state[3].marker + " | " + state[4].marker + " | " + state[5].marker + "\n";
            s += "          " + "-----------\n";
            s += "          " + state[6].marker + " | " + state[7].marker + " | " + state[8].marker + "\n";
            return s;
        }

        public void Mark(bool team, Position p)
        {
            var x = state.Single(t => t.x == p.x && t.y == p.y);
            x.occupied = true;
            x.marker = GetMarker(team);
        }

        public char GetMarker(bool t)
        {
            return t ? 'O' : 'X';
        }
    }
}
