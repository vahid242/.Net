using System;
using System.Collections.Generic;
using System.Text;

namespace A1VahidGhaedsharaf
{
    class Vehicle
    {
        public int id;
        public string name;
        public double price;
        public string category;
        public string type;
        public string available;

        public Vehicle(int vid, string vname, double vprice, string vcategory, string vtype, string vavailable)
        {
            id = vid;
            name = vname;
            price = vprice;
            category = vcategory;
            type = vtype;
            available = vavailable;
        }
    }
}
