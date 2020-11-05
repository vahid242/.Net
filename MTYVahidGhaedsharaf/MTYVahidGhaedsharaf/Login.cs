using System;
using System.Collections.Generic;
using System.Text;

namespace MTYVahidGhaedsharaf
{
    class Login
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Login(int id, string username, string password)
        {
            ID = id;
            Username = username;
            Password = password;
        }
    }
}
