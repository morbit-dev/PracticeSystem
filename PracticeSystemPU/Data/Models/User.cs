using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSystemPU.Data.Models
{
    public class User
    {
        public User()
        {
        }

        public User(string username, string password, string role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
        }

        public User(string username, string password, string role, string name)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Name = name;     
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}