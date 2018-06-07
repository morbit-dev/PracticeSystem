using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSystemPU.Data.Models
{
    public class Firm : User
    {
        public Firm()
        {
        }

        public Firm(string username, string password, string role, string name, string address, string description)
            : base(username, password, role, name)
        {
            this.Address = address;
            this.Description = description;
        }

        public string Address { get; set; }
        public string Description { get; set; }
        public ICollection<Internship> Internships { get; set; } = new List<Internship>();

    }
}