using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPPTennisScorer.Common;

namespace RPPTennisScorer
{
    internal class Set
    {

        public Game? CurrentGame = new Game();

        public Set()
        {
            CompletedSets = new List<Game>();
        }
        public List<Game> CompletedSets { get; private set; }
        public int SetsWonA => CompletedSets.Where(s => s.ScoreA > s.ScoreB).Count();
        public int SetsWonB => CompletedSets.Where(s => s.ScoreA < s.ScoreB).Count();

        /// <summary>
        /// Indicates whether the Game is complete, based on the present score. True if complete. 
        /// </summary>
        public bool Complete =>
            Math.Max(SetsWonA, SetsWonB) >= 6 && //One of the players must have won at least six games ("40" in tennis)
            Math.Abs(SetsWonA - SetsWonB) >= 2;  //And one of them must lead by at least two points 


        public void AddPointForPlayer(Player player)
        {
            if (CurrentGame is null) return; //means the game is complete
            if (player == Player.A) CurrentGame.ScoreA++; else CurrentGame.ScoreB++;
            if (CurrentGame.Complete)
            {
                CompletedSets.Add(CurrentGame);
                CurrentGame = Complete ? null : new Game();
            }
        }

        public string CurrentSetDescription => Complete ? "" : $"{SetsWonA}-{SetsWonB}";

        public string SetsWonEachDescription =>
            SetsWonA > 0 || SetsWonB > 0 //Only show running games total if at least 
            ? $"{SetsWonA}-{SetsWonB}"
            : string.Empty;


        ///// <summary>
        ///// Should return 
        ///// </summary>
        ///// <returns></returns>
        //public override string ToString()
        //{
        //    int playerScore;
        //    int otherPlayerScore;

        //    playerScore = player == Player.A ? ScoreA : ScoreB;
        //    otherPlayerScore = player == Player.A ? ScoreB : ScoreA;

        //    //Fallthrough possible scenarios...
        //    if (playerScore == 0) return "0";
        //    if (playerScore == 1) return "15";
        //    if (playerScore == 2) return "30";
        //    if (playerScore >= 3 && otherPlayerScore >= playerScore) return "40"; //Advatage, Other Player
        //    return "A"; //Advatage, Player
        //}



    }
}
