using System;
using System.Collections.Generic;
using System.Text;

namespace MTYVahidGhaedsharaf
{
    public enum PersonType
    {
        Player, Coach, Manager
    }
    public abstract class Person
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Person(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
