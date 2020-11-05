using System;
using System.Collections.Generic;
using System.Text;

namespace MTYVahidGhaedsharaf
{
    public class Coach : Person
    {
        private int _numberOfTeamsCoached;

        public int NumberOfTeamsCoached
        {
            get { return _numberOfTeamsCoached; }
            set { _numberOfTeamsCoached = value; }
        }

        private int _playersTrained;

        public int PlayersTrained
        {
            get { return _playersTrained; }
            set { _playersTrained = value; }
        }

        private double _winPercentage;

        public double WinPercentage
        {
            get { return _winPercentage; }
            set { _winPercentage = value; }
        }

        private int _yearsOfExperience;

        public int YearsOfExperience
        {
            get { return _yearsOfExperience; }
            set { _yearsOfExperience = value; }
        }

        public Coach(int id, string name, int numberOfTeamsCoached, int playersTrained, double winPercentage, int yearsOfExperience) :
            base(id, name)
        {
            NumberOfTeamsCoached = numberOfTeamsCoached;
            PlayersTrained = playersTrained;
            WinPercentage = winPercentage;
            YearsOfExperience = yearsOfExperience;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Team Coaced: {NumberOfTeamsCoached}, Players Trained: {PlayersTrained}" +
                $" Win Percentage: {WinPercentage}% years Of Experience: {YearsOfExperience}";
        }
    }
}
