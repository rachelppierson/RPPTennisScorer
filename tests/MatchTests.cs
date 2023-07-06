using RPPTennisScorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTests
{
    public class MatchTests
    {
        readonly Match _matchUnderTest;

        public MatchTests()
        {
            _matchUnderTest = new Match();
        }

        #region Test cases from the 'input' samples, tested invidually

        [Theory]
        [InlineData("", "0-0")]
        public void CheckTestSample1(string input, string expectedOutput)
        {
            //Act
            _matchUnderTest.ScoreMatch(input);
            var _actual = _matchUnderTest.ToString();

            //Assert
            Assert.Equal(expectedOutput, _actual);
        }

        #endregion
    }
}
