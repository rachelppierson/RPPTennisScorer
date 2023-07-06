using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPTennisScorer
{
    internal class Set
    {
        public int ScoreA { get; set; }
        public int ScoreB { get; set; }

        public override string ToString()
        {
            return $"{ScoreA}-{ScoreB}";
        }
    }
}
