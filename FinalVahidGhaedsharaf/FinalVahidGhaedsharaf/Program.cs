using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalVahidGhaedsharaf
{
    class Program
    {
        static void Main(string[] args)
        {
            CrudOperations crud = new CrudOperations();
            
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = crud.ShowMenu();
            }
        }

        
    }
}
