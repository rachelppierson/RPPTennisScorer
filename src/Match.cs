using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPPTennisScorer.Common;

namespace RPPTennisScorer
{
    internal class Match
    {
        public Set CurrentSet = new Set();
        public Player GetCurrentServer => (CompletedSets.SelectMany(s => s.CompletedGames).Count() + CurrentSet.CompletedGames.Count) % 2 == 0 ? Player.A : Player.B;

        public Match()
        {
            CompletedSets = new List<Set>();
        }

        public List<Set> CompletedSets { get; internal set; }
        public int SetsWonA => CompletedSets.Where(s => s.GamesWonA > s.GamesWonB).Count();
        public int SetsWonB => CompletedSets.Where(s => s.GamesWonA < s.GamesWonB).Count();


        internal void AddPointForPlayer(Player player)
        {
            CurrentSet.AddPointForPlayer(player);
            if (CurrentSet.Complete)
            {
                CompletedSets.Add(CurrentSet);
                CurrentSet = new Set() { CurrentServer = GetCurrentServer };
            }
        }

        internal void ScoreMatch(string pointsString)
        {
            Player currentScoringPlayer;

            foreach (char c in pointsString)
            {
                if (Enum.TryParse<Player>(c.ToString(), out currentScoringPlayer))
                    AddPointForPlayer(currentScoringPlayer);
                else
                    throw new InvalidDataException("You passed a string that included an invalid character - on 'A' or 'B' permitted");
            }
        }


        public string SetsWonDescription => $"{SetsWonA}-{SetsWonB}";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Player currentServer = GetCurrentServer;
            CurrentSet.CurrentServer = currentServer;
            foreach (Set s in CompletedSets)
            {
                s.CurrentServer = currentServer; //Updates all historical Sets to the current server.
                sb.Append($"{s.ToString()} ");
            }
            sb.Append(CurrentSet.ToString());
            return sb.ToString();
        }
    }
}
