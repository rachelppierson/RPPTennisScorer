using RPPTennisScorer;
using TennisTests.Mocks;
using static RPPTennisScorer.Common;

namespace TennisTests
{
    public class GameTests
    {
        readonly Game _gameUnderTest = new Game();

        public GameTests()
        {
            //NB: in xUnit, a new instance of this class is created for each test within. So you can effectively use Members and the Constructor as a re-usable Setup method.
        }

        #region Scoring Tests

        [Fact]
        public void NullScoreCheck()
        {
            //Setup
            var _expected = "0-0";

            //Act
            var _actual = _gameUnderTest.ToString();

            //Assert
            Assert.Equal(_expected, _actual);
        }

        [Fact]
        public void BasicScoreCheck()
        {
            //Setup
            _gameUnderTest.ScoreA = 1;
            _gameUnderTest.ScoreB = 2;
            var _expected = "15-30";

            //Act
            var _actual = _gameUnderTest.ToString();

            //Assert
            Assert.Equal(_expected, _actual);
        }

        [Fact]
        public void CheckFortyAll()
        {
            //Setup
            _gameUnderTest.ScoreA = 3;
            _gameUnderTest.ScoreB = 3;
            var _expected = "40-40";

            //Act
            var _actual = _gameUnderTest.ToString();

            //Assert
            Assert.Equal(_expected, _actual);
        }

        [Fact]
        public void CheckAdvantagePlayerA()
        {
            //Setup
            _gameUnderTest.ScoreB = ScoreMocks.RandomIntBetween(3, 100);
            _gameUnderTest.ScoreA = _gameUnderTest.ScoreB + 1;
            var _expected = "A-40";

            //Act
            var _actual = _gameUnderTest.ToString();

            //Assert
            Assert.Equal(_expected, _actual);
        }

        [Fact]
        public void CheckAdvantagePlayerB()
        {
            //Setup
            _gameUnderTest.ScoreA = ScoreMocks.RandomIntBetween(3, 100);
            _gameUnderTest.ScoreB = _gameUnderTest.ScoreA + 1;
            var _expected = "40-A";

            //Act
            var _actual = _gameUnderTest.ToString();

            //Assert
            Assert.Equal(_expected, _actual);
        }

        #endregion

        #region Set Complete Tests

        [Fact]
        public void CheckThatSetIsNotCompleteWhenScoresAreTooLow()
        {
            //Setup
            _gameUnderTest.ScoreA = ScoreMocks.RandomNonWinningScore();
            _gameUnderTest.ScoreB = ScoreMocks.RandomNonWinningScore();

            //Act
            var _actual = _gameUnderTest.Complete;

            //Assert
            Assert.False(_actual);
        }

        [Fact]
        public void CheckFortyWinsIfLeadingByAtLeastTwoPoints()
        {
            //Setup
            _gameUnderTest.ScoreA = (int)SetScore.Forty;
            _gameUnderTest.ScoreB = _gameUnderTest.ScoreA - 2;

            //Act
            var _actual = _gameUnderTest.Complete;

            //Assert
            Assert.True(_actual);
        }

        [Fact]
        public void CheckThatSetIsCompleteWhenPlayerAHasAWinningScoreAndLeadsByAtLeastTwoPoints()
        {
            //Setup
            _gameUnderTest.ScoreA = ScoreMocks.PotentiallyWinningScore();
            _gameUnderTest.ScoreB = _gameUnderTest.ScoreA - 2;

            //Act
            var _actual = _gameUnderTest.Complete;

            //Assert
            Assert.True(_actual);
        }

        [Fact]
        public void CheckThatSetIsNotCompleteWhenPlayerAHasAtLeast40ButPlayerBIsAtMostOnePointBehind()
        {
            //Setup
            _gameUnderTest.ScoreA = ScoreMocks.PotentiallyWinningScore();
            _gameUnderTest.ScoreB = _gameUnderTest.ScoreA - ScoreMocks.RandomIntBetween(0, 1); //Player B is at most 1 point below

            //Act
            var _actual = _gameUnderTest.Complete;

            //Assert
            Assert.False(_actual);
        }

        [Fact]
        public void CheckThatSetIsNotCompleteWhenPlayerBHasAtLeast40ButPlayerAIsAtMostOnePointBehind()
        {
            //Setup
            _gameUnderTest.ScoreB = ScoreMocks.PotentiallyWinningScore();
            _gameUnderTest.ScoreA = _gameUnderTest.ScoreB - ScoreMocks.RandomIntBetween(0, 1); //Player A is at most 1 point below

            //Act
            var _actual = _gameUnderTest.Complete;

            //Assert
            Assert.False(_actual);
        }


        #endregion
    }
}