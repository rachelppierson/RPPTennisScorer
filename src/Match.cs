using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPTennisScorer
{
    internal class Match
    {
        public List<Set> CompletedGames { get; private set; }
        //public int SetsWonA => CompletedGames.Where(s => s.ScoreA > s.ScoreB).Count();
        //public int SetsWonB => CompletedGames.Where(s => s.ScoreA < s.ScoreB).Count();

        public Match()
        {
            CompletedGames = new List<Set>();
        }
    }
}
