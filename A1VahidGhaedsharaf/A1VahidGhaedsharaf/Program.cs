 using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading;

namespace A1VahidGhaedsharaf
{   
    class Program
    {
        private static void ShowVehicle(List<Vehicle> allVehicle)
        {
            Console.Clear();
            Console.WriteLine("Id Name \t\t\t  Rental Price  Category  Type      Available");

            var show = from veh in allVehicle
                     select veh;
            foreach (var item in show)
            Console.WriteLine($"{item.id,-3}"+ $"{item.name,-35}"+
                $"{item.price,7}" + "   " + $"{item.category,-10}" +
                $"{item.type,-10}" + $"{item.available,-10}");
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        private static void AvialableVehicle(List<Vehicle> avVehicle)
        {
            Console.Clear();
            Console.WriteLine("Available Vehicles: \n\n");
            showList(avVehicle);
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        private static void Reserve(List<Vehicle> resevedVehicle)
        {
            Console.Clear();
            if (resevedVehicle.Count == 0)
            {
                showList(resevedVehicle);
            }
            else
            {
                showList(resevedVehicle);
                Console.Write("\r\nPress Enter key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void Reservation(List<Vehicle> avVehicle, List<Vehicle> resevedVehicle, List<Vehicle> allvedVehicl)
        {
            Console.Clear();
            Console.WriteLine("Available Vehicles: \n\n");
            showList(avVehicle);
            Console.Write("\r\nEnter vehicle ID to reseve: ");
            int select = int.Parse(Console.ReadLine());
            for(int i=0; i< avVehicle.Count; i++)
            {
                if (select == avVehicle[i].id)
                {
                    int myIndex = avVehicle[i].id - 1;
                    resevedVehicle.Add(avVehicle[i]);
                    avVehicle.RemoveAt(i);
                    allvedVehicl[myIndex].available = "No";
                }
            }
            Console.Clear();
            confirmation(ref select, resevedVehicle);
        }
        private static void confirmation(ref int a, List<Vehicle> resevedVehicle)
        {
            Console.WriteLine("vehicle Reservaton Successful");
            showList(resevedVehicle);
            Console.Write("\r\nPress Enter key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void CancelReserve(List<Vehicle> avVehicl, List<Vehicle> resevedVehicle, List<Vehicle> allVehicle)
        {
            Console.Clear();
            if (resevedVehicle.Count == 0)
            {
                showList(resevedVehicle);
            }
            else
            {
                showList(resevedVehicle);
                Console.Write("\r\nEnter vehicle ID to cancel reservation: ");
                int selectCancle = int.Parse(Console.ReadLine());
                for (int i = 0; i < resevedVehicle.Count; i++)
                {
                    if (selectCancle == resevedVehicle[i].id)
                    {
                        int myIndex = resevedVehicle[i].id - 1;
                        avVehicl.Add(resevedVehicle[i]);
                        sortList(avVehicl);
                        allVehicle[myIndex].available = "Yes";
                        resevedVehicle.RemoveAt(i);
                    }
                }
                
                Console.Clear();
                Console.Write("\r\nVehicle Resevation cancelled Successfully. \n");
                Console.Write("\r\nPress any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
            
        }

        private static void showList(List<Vehicle> allVehicle)
        {
            if (allVehicle.Count == 0)
            {
                Console.WriteLine("No records found. \n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Id Name \t\t\t  Rental Price  Category  Type");
                var show = from veh in allVehicle
                           select veh;
                foreach (var item in show)
                    Console.WriteLine($"{item.id,-3}" + $"{item.name,-35}" +
                $"{item.price,7}" + "   " + $"{item.category,-10}" +
                $"{item.type,-10}");

            }
        }

        private static void sortList(List<Vehicle> myList)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                for (int j = 0; j < myList.Count; j++)
                {
                    if(myList[i].id < myList[j].id)
                    {
                        Vehicle temp = myList[i];
                        myList[i] = myList[j];
                        myList[j] = temp;
                    }
                }
            }
        }

        private static bool ShowMenu(List<Vehicle> allVehicle, List<Vehicle> avVehicl, List<Vehicle> resevedVehicle)
        {
            Console.WriteLine("ASSIGNMENT-1 By VAHID GHAEDSHARAF \n");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-\n");
            Console.WriteLine("1 - View all vehicles");
            Console.WriteLine("2 - View avaialable vehicles");
            Console.WriteLine("3 - View reserved vehicles");
            Console.WriteLine("4 - Reserve a vehicle");
            Console.WriteLine("5 - Cancel resevation");
            Console.WriteLine("6 - Exit \n");

            Console.WriteLine("Enter your choice");
            int userChoose = int.Parse(Console.ReadLine());
            while (true)
            {
                if (userChoose == 1)
                {
                    ShowVehicle(allVehicle);
                    return true;
                }
                else if (userChoose == 2)
                {
                    AvialableVehicle(avVehicl);
                    return true;
                }
                else if (userChoose == 3)
                {
                    Reserve(resevedVehicle);
                    return true;
                }
                else if (userChoose == 4)
                {
                    Reservation(avVehicl, resevedVehicle, allVehicle);
                    return true;
                }
                else if (userChoose == 5)
                {
                    CancelReserve(avVehicl, resevedVehicle, allVehicle);
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
        static void Main(string[] args)
        {
            List<Vehicle> allVehicle = new List<Vehicle>()
            {
                new Car(1, "Honda Civic", 69.9, "Sedan", "Standard", "Yes"),
                new Car(2, "Toyota Corolla", 69.9, "Sedan", "Standard", "Yes"),
                new Car(3, "Ford Explorer", 99.9,   "SUV", "Standard", "Yes"),
                new Car(4, "Nissan Versa", 49.9, "Hatchback", "Standard", "Yes"),
                new Car(5, "Hyundai Tucson", 89.9, "SUV", "Standard", "Yes"),
                new Car(6, "Lamborghini Aventador", 189.9, "Sports", "Exotic", "Yes"),
                new Car(7, "Ferrari 488 GTB", 179.9, "Sports", "Exotic", "Yes"),
                new Car(8, "Mclaren p1", 199.9, "Sports", "Exotic", "Yes"),
                new Motorcycle(9, "Suzuki Boulevard M109R", 49.9, "Cruiser", "Bike", "Yes"),
                new Motorcycle(10, "Harley-Davidson street Glide", 79.9, "Cruiser", "Bike", "Yes"),
                new Motorcycle(11, "Honda CRF125", 39.9, "Dirt", "Bike", "Yes"),
                new Motorcycle(12, "Ducati Monster", 69.9, "Sports", "Bike", "Yes"),
                new Motorcycle(13, "Can_AM Spyder", 59.9, "Cruiser", "Trike", "Yes"),
                new Motorcycle(14, "Polaris Slignshot", 69.9, "Cruiser", "Trike", "Yes")
            };
            List<Vehicle> avVehicle = new List<Vehicle>();
            avVehicle.AddRange(allVehicle);
            List<Vehicle> reservedVehicle = new List<Vehicle>();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = ShowMenu(allVehicle, avVehicle, reservedVehicle);
            }
        }
        
    }  
}

