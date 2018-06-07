using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSystemPU.Data.Models
{
    public class Practice
    {

        public Practice()
        {
        }

        public Practice(string name, DateTime startDate, DateTime endDate)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Internship> Internships { get; set; } = new List<Internship>();

    }
}