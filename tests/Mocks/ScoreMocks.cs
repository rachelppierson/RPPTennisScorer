using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTests.Mocks
{
    internal static class ScoreMocks
    {
        //NB: 0 = Love, 1 = 15, 2 = 30, 3 = 40

        internal static int RandomIntBetween(int lower, int upper) => new Random().Next(lower, upper);

        internal static int RandomNonWinningScore() => RandomIntBetween(0, 2); //Scores lower than "30" can't be a winning score.

        internal static int PotentiallyWinningScore() => RandomIntBetween(3, 1000); //Scores higher than "40" may be a winning score, depending on the other player's score.
    }
}
