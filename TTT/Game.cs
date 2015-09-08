using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT
{
    public class Game
    {
        public Board board { get; set; }

        bool turn { get; set; }

        bool isLive { get; set; }

        public Game()
        {
            turn = false;
            isLive = true;
            board = new Board();
        }

        public void Start()
        {
            char winner = ' ';

            while (isLive)
            {
                int choice = 0;
                //Show board
                Print(board.ToString());

                //Show possible moves
                Print(ShowMoves() + "\nPlease enter valid move");

                //Choose & Accept move
                choice = GetInput(GetMoves().Count);
                board.Mark(turn, GetMoves()[choice-1]);

                //Resolve Winner
                if (ResolveWinner() != ' ')
                {
                    isLive = false;
                    winner = ResolveWinner();
                }
                //Check for a tie
                if (GetMoves().Count == 0)
                {
                    isLive = false;
                    winner = '!';
                }
                //Switch turns and continue playing
                SwitchTurn();
            }
            Print(board.ToString());
            Print(DeclareWinner(winner));
            Print("Press any key to exit...");
            Console.ReadKey();
        }
        public string DeclareWinner(char w)
        {
            if (w != '!')
                return string.Format("\n\nTeam {0} is the Winner!!!!!\n\n", w);
            else
                return "\n\nIt's a tie!!!! Holy moley!!!!\n\n";
        }
        public char ResolveWinner()
        {
            //Condition 1/8
            if (board.state[0].marker == board.state[1].marker && board.state[1].marker == board.state[2].marker)
            {
                return board.state[0].marker;
            }

            //Condition 2/8
            if (board.state[3].marker == board.state[4].marker && board.state[4].marker == board.state[5].marker)
            {
                return board.state[3].marker;
            }

            //Condition 3/8
            if (board.state[6].marker == board.state[7].marker && board.state[7].marker == board.state[8].marker)
            {
                return board.state[7].marker;
            }

            //Condition 4/8
            if (board.state[0].marker == board.state[3].marker && board.state[3].marker == board.state[6].marker)
            {
                return board.state[0].marker;
            }

            //Condition 5/8
            if (board.state[1].marker == board.state[4].marker && board.state[4].marker == board.state[7].marker)
            {
                return board.state[1].marker;
            }

            //Condition 6/8
            if (board.state[2].marker == board.state[5].marker && board.state[5].marker == board.state[8].marker)
            {
                return board.state[2].marker;
            }

            //Condition 7/8
            if (board.state[0].marker == board.state[4].marker && board.state[4].marker == board.state[8].marker)
            {
                return board.state[0].marker;
            }

            //Condition 8/8
            if (board.state[2].marker == board.state[4].marker && board.state[4].marker == board.state[6].marker)
            {
                return board.state[2].marker;
            }
            return ' ';
        }

        public int GetInput(int numMoves)
        {
            bool validEntry = false;
            int moveNum = 0;
            char input = ' ';
            while (!validEntry)
            {
                input = Console.ReadKey().KeyChar;
                try { moveNum = int.Parse(input.ToString()); } catch { };
                if (moveNum < 1 || moveNum > numMoves)
                {
                    Console.WriteLine("\nPlease enter valid move\n");
                    Print(board.ToString());
                }
                else { validEntry = true; }
            }
            return moveNum;
        }

        public void SwitchTurn()
        {
            turn = !turn;
        }

        public List<Position> GetMoves()
        {
            List<Position> l = new List<Position>();
            foreach (Position p in board.state)
            {
                if (!p.occupied)
                {
                    l.Add(p);
                }
            }
            return l;

        }

        public string ShowMoves()
        {
            List<Position> l = GetMoves();
            int c = 1;
            string s = "";
            foreach (Position p in l)
            {
                s += String.Format("({0}) ({1}, {2})\n",c, p.x, p.y);
                c++;
            }
            return s;
        }
        public void Print(string s)
        {
            Console.WriteLine(s);
        }
    }
}
