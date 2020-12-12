using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Threading;


namespace A2VahidGhaedsharaf
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintEmployess();
            //string cs = GetConnectionString("NorthwindLocal");
            //Console.WriteLine(cs);
            //GetEmployeeByName();
            //SortByAge();
            //PrintOrder();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = ShowMenu();
            }
        }

        private static bool ShowMenu()
        {
            Console.WriteLine("ASSIGNMENT-2 By VAHID GHAEDSHARAF \n");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-\n");
            Console.WriteLine("1 - Get all Employees");
            Console.WriteLine("2 - Search Employees by Name");
            Console.WriteLine("3 - Sort Employees by Age");
            Console.WriteLine("4 - Get all Orders");
            Console.WriteLine("5 - Exit");

            Console.WriteLine("Enter your choice");
            int userChoose = int.Parse(Console.ReadLine());

            while (true)
            {
                if (userChoose == 1)
                {
                    PrintEmployess();
                    return true;
                }
                else if (userChoose == 2)
                {
                    GetEmployeeByName();
                    return true;
                }

                else if (userChoose == 3)
                {
                    SortByAge();
                    return true;
                }

                else if (userChoose == 4)
                {
                    PrintOrder();
                    return true;
                }

                else if (userChoose == 5)
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

        static void PrintEmployess()
        {
            Console.Clear();
            Console.WriteLine("\n+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+- \n Employees:\n");
            Console.WriteLine($"Emp ID First name\t Last Name\t Title\t\t\t   Birth Date \n");
            string cs = GetConnectionString("NorthwindLocal");
            SqlConnection conn = new SqlConnection(cs);
            string query = "Select EmployeeID, FirstName, LastName, Title," +
                "BirthDate from Employees";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = (int)reader["EmployeeID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string title = (string)reader["Title"];
                DateTime birthDate = (DateTime)reader["BirthDate"];
                Console.WriteLine($"{id,6} {firstName,-17} {lastName,-15} {title,-25} {birthDate.ToString("dd-MMM-yy"),10}");
            }
            conn.Close();

            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        static void GetEmployeeByName()
        {
            Console.Clear();
            Console.Write("Enter Employee name: "); 
            string eName = Console.ReadLine();
            Console.WriteLine("\n+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+- \n Search  Employees by Name:\n");
            Console.WriteLine($"Emp ID First name\t Last Name\t Title\t\t\t   Birth Date \n");

            string cs = GetConnectionString("NorthwindLocal");

            string query = "Select EmployeeID ,FirstName, LastName, Title," +
                "BirthDate from Employees Where FirstName LIKE '%' + @EmName + '%' OR LastName LIKE '%' + @EmName + '%'";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("EmName", eName);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string title = reader.GetString(3);
                    DateTime birthDate = reader.GetDateTime(4);
                    Console.WriteLine($"{id,6} {firstName,-17} {lastName,-15} {title,-25} {birthDate.ToString("dd-MMM-yy"),10}");
                }
            }
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        
        static void SortByAge()
        {
            Console.Clear();
            Console.WriteLine("\n+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+- \n Employees sorted by Age:\n");
            Console.WriteLine($"Emp ID First name\t Last Name\t Title\t\t\t   Birth Date\t\t Age \n");
            string cs = GetConnectionString("NorthwindLocal");
            string query = "Select EmployeeID, FirstName, LastName, Title, " +
               "BirthDate from Employees ORDER BY BirthDate";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string title = reader.GetString(3);
                    DateTime birthDate = reader.GetDateTime(4);
                    int year = DateTime.Now.Year - reader.GetDateTime(4).Year;
                    //Console.WriteLine($"{id,5} {firstName,-15} {lastName,-15} {birthDate,10} {year,10}");
                    Console.WriteLine($"{id,6} {firstName,-17} {lastName,-15} {title,-25} {birthDate.ToString("dd-MMM-yy"),10} {year,10} years");
                }
            }
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        static void PrintOrder()
        {
            Console.Clear();
            Console.WriteLine("\n+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+- \n Orders:\n");
            Console.WriteLine($"order ID Employee Name\t\tOrder Date\tShip Date\tCity\t\t Country \n");
            string cs = GetConnectionString("NorthwindLocal");
            string query = "Select Orders.OrderID, Employees.FirstName, Employees.LastName, Orders.OrderDate, Orders.ShippedDate, " +
               "Orders.ShipCity, Orders.ShipCountry  from Employees " +
               "LEFT JOIN Orders ON Employees.EmployeeID = Orders.EmployeeID WHERE Orders.OrderID > 10247  AND Orders.OrderID < 10258";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int orderID = reader.GetInt32(0);
                    string FirstName = reader.GetString(1);
                    string LastName = reader.GetString(2);
                    DateTime orderDate  = reader.GetDateTime(3);
                    DateTime shipDate = reader.GetDateTime(4);
                    string city = reader.GetString(5);
                    string country = reader.GetString(6);
                    Console.WriteLine($"{orderID,8} {FirstName,-8} {LastName,-13} {orderDate.ToString("dd-MMM-yy"),-10} {shipDate.ToString("dd-MMMM-yyyy"),15}\t{city,-15}  {country,-15}");
                }
            }
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        static string GetConnectionString(string connectionStringName)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("config.json");
            IConfiguration config = builder.Build();
            return config["ConnectionsStrings:" + connectionStringName];

        }
    }
}
