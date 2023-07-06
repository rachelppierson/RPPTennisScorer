using RPPTennisScorer;
using TennisTests.Mocks;

namespace TennisTests
{
    public class SetTests
    {
        readonly Set _setUnderTest = new Set();

        public SetTests()
        {
            //NB: in xUnit, a new instance of this class is created for each test within. So you can effectively use Members and the Coinstructor as a re-usable Setup method.
        }

        #region Scoring Tests

        [Fact]
        public void NullScoreCheck()
        {
            //Setup
            var _expected = "0-0";

            //Act
            var _actual = _setUnderTest.ToString();

            //Assert
            Assert.Equal(_expected, _actual);
        }

        [Fact]
        public void BasicScoreCheck()
        {
            //Setup
            _setUnderTest.ScoreA = 1;
            _setUnderTest.ScoreB = 2;
            var _expected = "1-2";

            //Act
            var _actual = _setUnderTest.ToString();

            //Assert
            Assert.Equal(_expected, _actual);
        }

        #endregion

        #region Set Complete Tests

        [Fact]
        public void CheckThatSetIsNotCompleteWhenScoresAreTooLow()
        {
            //Setup
            _setUnderTest.ScoreA = ScoreMocks.RandomNonWinningScore();
            _setUnderTest.ScoreB = ScoreMocks.RandomNonWinningScore();

            //Act
            var _actual = _setUnderTest.Complete();

            //Assert
            Assert.False(_actual);
        }

        [Fact]
        public void CheckThatSetIsCompleteWhenPlayerAHasAWinningScore()
        {
            //Setup
            _setUnderTest.ScoreA = ScoreMocks.PotentiallyWinningScore();
            _setUnderTest.ScoreB = _setUnderTest.ScoreA - 2;

            //Act
            var _actual = _setUnderTest.Complete();

            //Assert
            Assert.True(_actual);
        }

        [Fact]
        public void CheckThatSetIsNotCompleteWhenPlayerBIsAtMostOnePointBehind()
        {
            //Setup
            _setUnderTest.ScoreA = ScoreMocks.PotentiallyWinningScore();
            _setUnderTest.ScoreB = _setUnderTest.ScoreA - ScoreMocks.RandomIntBetween(0, 1); //Player B is at most 1 point below

            //Act
            var _actual = _setUnderTest.Complete();

            //Assert
            Assert.False(_actual);
        }

        [Fact]
        public void CheckThatSetIsNotCompleteWhenPlayerAIsAtMostOnePointBehind()
        {
            //Setup
            _setUnderTest.ScoreB = ScoreMocks.PotentiallyWinningScore();
            _setUnderTest.ScoreA = _setUnderTest.ScoreB - ScoreMocks.RandomIntBetween(0, 1); //Player A is at most 1 point below

            //Act
            var _actual = _setUnderTest.Complete();

            //Assert
            Assert.False(_actual);
        }


        #endregion
    }
}