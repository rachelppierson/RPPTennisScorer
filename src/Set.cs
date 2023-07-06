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
        public Game CurrentGame = new();

        public Player CurrentServer => CompletedGames.Count % 2 == 0 ? Player.A : Player.B;

        public Set()
        {
            CompletedGames = new List<Game>();
        }

        public List<Game> CompletedGames { get; internal set; }
        public int GamesWonA => CompletedGames.Where(s => s.ScoreA > s.ScoreB).Count();
        public int GamesWonB => CompletedGames.Where(s => s.ScoreA < s.ScoreB).Count();

        /// <summary>
        /// Indicates whether the Set is complete, based on the present score. True if complete. 
        /// </summary>
        public bool Complete =>
            Math.Max(GamesWonA, GamesWonB) >= 6 && //One of the players must have won at least six games
            Math.Abs(GamesWonA - GamesWonB) >= 2;  //And one of them must lead by at least two games


        public void AddPointForPlayer(Player player)
        {
            if (CurrentGame is null) return; //means the Set is complete
            if (player == Player.A) CurrentGame.ScoreA++; else CurrentGame.ScoreB++;
            if (CurrentGame.Complete)
            {
                CompletedGames.Add(CurrentGame);
                CurrentGame = new Game();
            }
        }
        public string GamesWonDescription => $"{GamesWonA}-{GamesWonB}";

        public string CurrentGameDescription =>
            CurrentGame.ScoreA == 0 && CurrentGame.ScoreB == 0
            ? string.Empty
            : CurrentGame.GetScore(CurrentServer);

        public override string ToString() => $"{GamesWonDescription} {CurrentGameDescription}".Trim();
    }
}
