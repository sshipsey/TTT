using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT
{
    class TTT
    {
        static void Main(string[] args)
        {
            //Team 0 = X, Team 1 = O
            Game g = new Game();
            g.Start();
            Console.ReadKey();
        }
    }
}
