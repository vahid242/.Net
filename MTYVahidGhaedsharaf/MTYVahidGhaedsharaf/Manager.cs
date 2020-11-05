using System;
using System.Collections.Generic;
using System.Text;

namespace MTYVahidGhaedsharaf
{
    public class Manager : Person
    {
        private int _playersRecruited;

        public int PlayersRecruited
        {
            get { return _playersRecruited; }
            set { _playersRecruited = value; }
        }

        private double _availableBudget;

        public double AvailableBudget
        {
            get { return _availableBudget; }
            set { _availableBudget = value; }
        }

        private string _strength;

        public string Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

        public Manager(int id, string name, int playersRecruited, double availableBudget, string strength) :
            base(id, name)
        {
            PlayersRecruited = playersRecruited;
            AvailableBudget = availableBudget;
            Strength = strength;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Players Recruited: {PlayersRecruited}, Available Budget: {AvailableBudget}M, Strength:{Strength}";
        }
    }
}
