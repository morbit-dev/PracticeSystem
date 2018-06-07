using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSystemPU.Data.Models
{
    public class Internship
    {
        public Internship()
        {
        }

        public Internship(int spots, Firm firm, Practice practice)
        {
            this.Spots = spots;
            this.Firm = firm;
            this.Practice = practice;
        }



        public int Id { get; set; }
        public int Spots { get; set; }
        public int FirmId { get; set; }
        public Firm Firm { get; set; }
        public int PracticeId { get; set; }
        public Practice Practice { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}