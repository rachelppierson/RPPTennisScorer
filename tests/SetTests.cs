using RPPTennisScorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTests.Helpers;
using TennisTests.Mocks;

namespace TennisTests
{
    public  class SetTests
    {
        readonly Set _setUnderTest;

        public SetTests()
        {
            _setUnderTest = new Set();
        }

        #region "No current game" tests

        [Fact]
        public void CheckOutputIsCorrectIfPlayerAWinsSetAndNoSetIsOngoing()
        {
            //Setup
            int PlayerAGamesWon = NumberHelpers.RandomIntBetween(6, 8); //Player A has won between 6 and 8 games
            int PlayerBGamesWon = NumberHelpers.RandomIntBetween(2, PlayerAGamesWon - 2); //Player B has won at least two games fewer
            _setUnderTest.CompletedGames = SetScoreMocks.MockCompletedGames(PlayerAGamesWon, PlayerBGamesWon);
            string _expected = $"{PlayerAGamesWon}-{PlayerBGamesWon}";

            //Act
            var _actual = _setUnderTest.ToString();

            //Assert
            Assert.Equal(_expected, _actual);
        }

        #endregion


    }
}
