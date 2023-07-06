using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPTennisScorer
{
    internal class Match
    {
        public List<Match> Matches { get; private set; }

        public Match()
        {
            Matches = new List<Match>();
        }
    }
}
