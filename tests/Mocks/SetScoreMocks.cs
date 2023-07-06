using RPPTennisScorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTests.Helpers;

namespace TennisTests.Mocks
{
    internal static class SetScoreMocks
    {
        internal static List<Game> MockCompletedGames(int numSetsPlayerAWon = 0, int numSetsPlayerBWon = 0)
        {
            List<Game> returnValue = new List<Game>();

            while (numSetsPlayerAWon != 0)
            {
                returnValue.Add(GameScoreMocks.PlayerAWins());
                numSetsPlayerAWon--;
            }
            while (numSetsPlayerBWon != 0)
            {
                returnValue.Add(GameScoreMocks.PlayerBWins());
                numSetsPlayerBWon--;
            }

            return returnValue;
        }

        /// <summary>
        /// If the winning score in a Set is greater than 6, the losing score must be two less than whatever it is. Otherwise it can be any lesser number.
        /// e.g., it's not possible to win 7-3, as you'd have already won upon reaching 6. This mock ensures that any losing score is consistent with these expectations.
        /// </summary>
        /// <param name="winningScore"></param>
        /// <returns></returns>
        internal static int GetLosingScoreFor(int winningScore) => winningScore > 6 ? winningScore - 2 : NumberHelpers.RandomIntBetween(0, winningScore - 2);

    }
}
