using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSystemPU.Data.Models
{
    public class Student : User
    {
        public Student()
        {
        }

        public Student(string username, string password, string role, string name,int fn, float avgGrade, Internship internship)
            :base(username, password, role, name)
        {
            this.Fn = fn;
            this.AvgGrade = avgGrade;
            this.Internship = internship;
        }

        public int Fn { get; set; }
        public float AvgGrade { get; set; }
        public int InternshipId { get; set; }
        public Internship Internship { get; set; }

    }

}