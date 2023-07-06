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
        public void CheckNilNilIsDisplayedWhereNoGAmesPlayedYetAndNoGameOngoing()
        {
            //Setup
            string _expected = $"0-0"; //NB - no current game

            //Act
            var _actual = _setUnderTest.ToString();

            //Assert
            Assert.Equal(_expected, _actual);
        }


        [Fact]
        public void CheckOutputIsCorrectIfPlayerBHasWonMoreGamesAndNoGameIsOngoing()
        {
            //Setup
            int PlayerBGamesWon = NumberHelpers.RandomIntBetween(6, 8); //Player A has won between 6 and 8 games
            int PlayerAGamesWon = SetScoreMocks.GetLosingScoreFor(PlayerBGamesWon); //Player B has won at least two games fewer, possibly even fewer depending on Player A's score
            _setUnderTest.CompletedGames = SetScoreMocks.MockCompletedGames(PlayerAGamesWon, PlayerBGamesWon);
            string _expected = $"{PlayerAGamesWon}-{PlayerBGamesWon}"; //NB - no current game

            //Act
            var _actual = _setUnderTest.ToString();

            //Assert
            Assert.Equal(_expected, _actual);
        }

        [Fact]
        public void CheckOutputIsCorrectIfPlayerAHasWonMoreGamesAndNoGameIsOngoing()
        {
            //Setup
            int PlayerAGamesWon = NumberHelpers.RandomIntBetween(6, 8); //Player A has won between 6 and 8 games
            int PlayerBGamesWon = SetScoreMocks.GetLosingScoreFor(PlayerAGamesWon); //Player B has won at least two games fewer, possibly even fewer depending on Player A's score
            _setUnderTest.CompletedGames = SetScoreMocks.MockCompletedGames(PlayerAGamesWon, PlayerBGamesWon);
            string _expected = $"{PlayerAGamesWon}-{PlayerBGamesWon}"; //NB - no current game

            //Act
            var _actual = _setUnderTest.ToString();

            //Assert
            Assert.Equal(_expected, _actual);
        }

        #endregion


    }
}
