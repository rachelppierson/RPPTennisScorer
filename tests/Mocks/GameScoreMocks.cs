using RPPTennisScorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTests.Helpers;

namespace TennisTests.Mocks
{
    internal static class GameScoreMocks
    {
        //NB: 0 = Love, 1 = 15, 2 = 30, 3 = 40

        internal static int RandomNonWinningScore() => NumberHelpers.RandomIntBetween(0, 2); //Scores lower than "30" can't be a winning score.

        internal static int PotentiallyWinningScore() => NumberHelpers.RandomIntBetween(3, 100); //Scores higher than "40" may be a winning score, depending on the other player's score.

        internal static Game PlayerAWins()
        {
            int winningScore = PotentiallyWinningScore();
            int losingScore = NumberHelpers.RandomIntBetween(0, winningScore - 2);
            return new Game() { ScoreA = winningScore, ScoreB = losingScore };
        }

        internal static Game PlayerBWins()
        {
            int winningScore = PotentiallyWinningScore();
            int losingScore = NumberHelpers.RandomIntBetween(0, winningScore - 2);
            return new Game() { ScoreB = winningScore, ScoreA = losingScore };
        }
    }
}
