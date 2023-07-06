using static RPPTennisScorer.Common;

namespace RPPTennisScorer
{
    internal class Game
    {
        public int ScoreA { get; set; } //NB: 0 = Love, 1 = 15, 2 = 30, 3 = 40
        public int ScoreB { get; set; }

        public string GetScore(Player currentServer) =>
            currentServer == Player.A  
            ? $"{ScoreDescription(Player.A)}-{ScoreDescription(Player.B)}"
            : $"{ScoreDescription(Player.B)}-{ScoreDescription(Player.A)}";

        /// <summary>
        /// Indicates whether the Set is complete, based on the present score. True if complete. 
        /// </summary>
        public bool Complete =>
            Math.Max(ScoreA, ScoreB) > 3 && //One of the players must have at least three points ("40" in tennis + one winning game point)
            Math.Abs(ScoreA - ScoreB) >= 2;  //And one of them must lead by at least two points 

        string ScoreDescription(Player player)
        {
            int playerScore;
            int otherPlayerScore;

            playerScore = player == Player.A ? ScoreA : ScoreB;
            otherPlayerScore = player == Player.A ? ScoreB : ScoreA;

            //Fallthrough possible scenarios...
            if (playerScore == 0) return "0";
            if (playerScore == 1) return "15";
            if (playerScore == 2) return "30";
            if (playerScore == 3) return "40";
            if (playerScore > 3 && otherPlayerScore >= playerScore) return "40"; //Advatage, Other Player
            return "A"; //Advatage, Player
        }
    }
}
