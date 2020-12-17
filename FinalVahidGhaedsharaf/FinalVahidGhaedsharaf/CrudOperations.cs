using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FinalVahidGhaedsharaf
{
    class CrudOperations
    {
        internal void GetCity()
        {
            Console.Clear();
            string capital="";
            using (var ctx = new WorldDBEntities())
            {
                var city = (from s in ctx.Cities
                            join c in ctx.Countries on s.CountryID equals c.CountryID
                            join g in ctx.Continents on c.ContinentID equals g.ContinentID
                            select new
                            {
                                CityID = s.CityID,
                                CityName = s.CityName,
                                IsCapital = s.IsCapital,
                                CountryName = c.CountryName,
                                pop = s.Population,
                                ContName = g.ContinentName
                            }).ToList();
                Console.WriteLine("CityId City Name    Is Capiral  Country Name \t   Continent Name \t   Population");

                foreach (var std in city)
                { 
                    if (std.IsCapital)
                    {
                        capital = "Yes";
                    }
                    else
                    {
                        capital = "";
                    }
                    
                    Console.WriteLine($"{std.CityID,6} {std.CityName,-16} {capital, -10} {std.CountryName, -20} {std.ContName, -20} {std.pop, -10}");
                }

            }
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        internal void GetCountries()
        {
            Console.Clear();
            using (var ctx = new WorldDBEntities())
            {
                var coun = (from c in ctx.Countries
                            join g in ctx.Continents on c.ContinentID equals g.ContinentID
                            select new
                            {
                                CountryID = c.CountryID,
                                CountryName = c.CountryName,
                                ContName = g.ContinentName,
                                lan = c.Language,
                                cur = c.Currency
                            }).ToList();

                Console.WriteLine("Country ID Country Name   Contient Name \tLanguage \t\tCurrancy");
                foreach (var std in coun)
                {
                    Console.WriteLine($"{std.CountryID,10} {std.CountryName,-15} {std.ContName, -20} {std.lan, -20} {std.cur, -30}");
                }

            }

            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        internal void InsertCountry()
        {
            Console.Clear();
            using (var ctx = new WorldDBEntities())
            {
                Console.WriteLine("Please pay attention to complete all requests");
                var con = (from g in ctx.Continents
                           select g).ToList();

                var cnt = new Country();
                Console.Write("Enter country name: ");
                string uName = Console.ReadLine();
                cnt.CountryName = uName;
                Console.Write("Enter code: ");
                string uCode = Console.ReadLine();
                cnt.CountryCode = uCode;
                Console.Write("Enter language: ");
                string ulan = Console.ReadLine();
                cnt.Language = ulan;
                Console.Write("Enter currency: ");
                string ucur = Console.ReadLine();
                cnt.Currency = ucur;
                Console.WriteLine("Enter continent ID: ");
                foreach (var cn in con)
                {
                    Console.WriteLine($"{cn.ContinentID,5} {cn.ContinentName, -20}");
                }
                int ucon = Convert.ToInt32(Console.ReadLine());
                cnt.ContinentID = ucon;

                ctx.Countries.Add(cnt);
                ctx.SaveChanges();

                Console.WriteLine($"{cnt.CountryName} is added to Countries");

                Console.Write("\r\nPress Enter to return to Main Menu");
                Console.ReadLine();
                Console.Clear();

            }
        }

        internal void InsertCity()
        {
            Console.Clear();
            using (var ctx = new WorldDBEntities())
            {
                Console.WriteLine("Please pay attention to complete all requests");
                var cnt = (from c in ctx.Countries
                           select c).ToList();
                var cty = new City();

                Console.Write("Enter City name: ");
                string uName = Console.ReadLine();
                cty.CityName = uName;
                Console.Write("Is Capital: enter Y for YES and N for NO: ");
                string cap = Console.ReadLine();
                if (cap == "y" || cap == "Y")
                {
                    cty.IsCapital = true;
                }
                else
                {
                    cty.IsCapital = false;
                }
                Console.Write("Enter Population: ");
                int pop = Convert.ToInt32(Console.ReadLine());
                cty.Population = pop;
                Console.Write("Enter Country ID: ");
                foreach (var cn in cnt)
                {
                    Console.WriteLine($"{cn.CountryID,5} {cn.CountryName,-20}");
                }
                int con = Convert.ToInt32(Console.ReadLine());
                cty.CountryID = con;

                ctx.Cities.Add(cty);
                ctx.SaveChanges();
                Console.WriteLine($"{cty.CityName} is added to Cities");
            }
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        internal void UpdateCity()
        {
            Console.Clear();
            string capital = "";
            using (var ctx = new WorldDBEntities())
            {
                var city = (from s in ctx.Cities
                            join c in ctx.Countries on s.CountryID equals c.CountryID
                            join g in ctx.Continents on c.ContinentID equals g.ContinentID
                            select new
                            {
                                CityID = s.CityID,
                                CityName = s.CityName,
                                IsCapital = s.IsCapital,
                                CountryName = c.CountryName,
                                CountryID= c.CountryID,
                                pop = s.Population,
                                ContName = g.ContinentName
                            }).ToList();
                foreach (var std in city)
                {
                    Console.WriteLine($"{std.CityID,5} {std.CityName,-20}");
                }

                var cnt = (from c in ctx.Countries
                           select c).ToList();
                Console.Write("Enter City ID to update: ");
                int uID = Convert.ToInt32(Console.ReadLine());
                var uCity = ctx.Cities.Find(uID);

                if (uCity.IsCapital)
                {
                    capital = "Yes";
                }
                else
                {
                    capital = "";
                }

                Console.WriteLine($"{uCity.CityID,5} {uCity.CityName,-20} {capital,-5} {uCity.Population,-20} {uCity.CountryID,-20}");

                Console.WriteLine("Please pay attention to complete all requests");
                Console.Write("Enter City name: ");
                string uName = Console.ReadLine();
                uCity.CityName = uName;
                Console.Write("Is Capital: enter Y for YES and N for NO: ");
                string cap = Console.ReadLine();
                if (cap == "y" || cap == "Y")
                {
                    uCity.IsCapital = true;
                }
                else
                {
                    uCity.IsCapital = false;
                }
                Console.Write("Enter Population: ");
                int pop = Convert.ToInt32(Console.ReadLine());
                uCity.Population = pop;
                Console.WriteLine("Enter Country ID: ");
                foreach (var cn in cnt)
                {
                    Console.WriteLine($"{cn.CountryID,5} {cn.CountryName,-20}");
                }
                int con = Convert.ToInt32(Console.ReadLine());
                uCity.CountryID = con;
                ctx.SaveChanges();

                Console.WriteLine($"{uCity.CityName} is updated");
            }
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }


        internal bool ShowMenu()
        {
            Console.WriteLine("1 - Get all Cities");
            Console.WriteLine("2 - Get all Countries");
            Console.WriteLine("3 - Add New Country");
            Console.WriteLine("4 - Add New Cities");
            Console.WriteLine("5 - Update a City");
            Console.WriteLine("6 - Exit");

            Console.WriteLine("Enter your choice");
            int userChoose = int.Parse(Console.ReadLine());

            while (true)
            {
                if (userChoose == 1)
                {
                    GetCity();
                    return true;
                }
                else if (userChoose == 2)
                {
                    GetCountries();
                    return true;
                }

                else if (userChoose == 3)
                {
                    InsertCountry();
                    return true;
                }

                else if (userChoose == 4)
                {
                    InsertCity();
                    return true;
                }

                else if (userChoose == 5)
                {
                    UpdateCity();
                    return true;
                }

                else if (userChoose == 6)
                {
                    Console.Write("good luck");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Error! Wrong Choice.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return true;
                }
            }

        }

    }
}
