using System;
using System.Collections.Generic;
using System.Text;

namespace MTYVahidGhaedsharaf
{
    public class Player : Person
    {
        private int _matchPlayed;

        public int MatchPlayed
        {
            get { return _matchPlayed; }
            set { _matchPlayed = value; }
        }

        private int _won;

        public int Won
        {
            get { return _won; }
            set { _won = value; }
        }

        private int _lost;

        public int Lost
        {
            get { return _lost; }
            set { _lost = value; }
        }
        private int _goalsScored;

        public int GoalsScored
        {
            get { return _goalsScored; }
            set { _goalsScored = value; }
        }

        public Player(int id, string name,int matchPlayed, int won, int lost, int goalsScored) : 
            base(id, name)
        {
            MatchPlayed = matchPlayed;
            Won = won;
            Lost = lost;
            GoalsScored = goalsScored;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Matches: {MatchPlayed} Won: {Won} " +
                $"Lost: {Lost} golsScored: {GoalsScored}";
        }
    }
}
