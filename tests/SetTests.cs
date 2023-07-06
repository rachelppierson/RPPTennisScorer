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
            var _scoreA = 1;
            var _scoreB = 2;
            var _expected = "1-2";

            //Act
            _setUnderTest.ScoreA = _scoreA;
            _setUnderTest.ScoreB = _scoreB;
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
            var _scoreA = ScoreMocks.RandomNonWinningScore();
            var _scoreB = ScoreMocks.RandomNonWinningScore();

            //Act
            var _actual = _setUnderTest.Complete();

            //Assert
            Assert.False(_actual);
        }

        #endregion
    }
}