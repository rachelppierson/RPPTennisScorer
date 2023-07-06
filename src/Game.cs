using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPTennisScorer
{
    internal class Game
    {
        public List<Set> Sets { get; private set; }

        public Game()
        {
            Sets = new List<Set>();
        }
    }
}
