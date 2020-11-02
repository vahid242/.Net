using System;
using System.Collections.Generic;
using System.Text;

namespace A1VahidGhaedsharaf
{
    class Car:Vehicle
    {
        public Car(int vid, string vname, double vprice, string vcategory, string vtype, string vavailable)
            : base(vid, vname, vprice, vcategory, vtype, vavailable) { }
        public void DisplayInfo()
        {
            //Console.WriteLine("Id Name \t\t Rental Price Category Type Available");
            Console.WriteLine($"{id} {name} \t\t {price} {category} {type} {available}");
        }
    }
}
