using Microsoft.EntityFrameworkCore;
using PracticeSystemPU.Data;
using PracticeSystemPU.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSystemPU
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var context = new PracticeSystemDbContext();

            //ResetDatabase(context);
            // ^ use when starting for first time.
            // ^
            // ^
            // ^

        }

        private static void ResetDatabase(PracticeSystemDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.Migrate();

            Seed(context);
        }

        private static void Seed(PracticeSystemDbContext context)
        {
            

            var practice = new Practice("FMI Summer Practices for 2018", DateTime.Parse("20/06/2018"), DateTime.Parse("21/09/2018"));
            context.Practice.Add(practice);

            var firm = new Firm("scale", "scalepass", "firm", "ScaleFocus", "Plovdiv, Dunav 5", "Outsorcing company");
            context.Firms.Add(firm);

            var internship = new Internship(6, firm, practice);
            context.Internships.Add(internship);

            var users = new[]
            {
                new User("admin", "adminpass", "admin", "Admin"),
                //new Firm("scale", "scalepass", "firm", "ScaleFocus", "Plovdiv, Dunav 5", "Outsorcing company"),
                new Student("st", "stpass", "student", "Stefan", 1234567890, 5.88f, internship)
            };

            context.Users.AddRange(users);
            

            context.SaveChanges();
        }
    }
}