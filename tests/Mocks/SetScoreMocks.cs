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
    }
}
