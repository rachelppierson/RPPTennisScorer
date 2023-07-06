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

        internal static int RandomNonWinningScore() => new Random().Next(0, 2); //Scores lower than "30" can't be a winning score.

        internal static int PotentiallyWinningScore() => new Random().Next(3, 1000); //Scores higher than "40" may be a winning score, depending on the other player's score.
    }
}
