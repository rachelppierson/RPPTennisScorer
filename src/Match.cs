using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPTennisScorer
{
    internal class Match
    {
        public List<Set> CompletedSets { get; private set; }
        public int SetsWonA => CompletedSets.Where(s => s.GamesWonA > s.GamesWonB).Count();
        public int SetsWonB => CompletedSets.Where(s => s.GamesWonB < s.GamesWonB).Count();

        public Match()
        {
            CompletedSets = new List<Set>();
        }
    }
}
