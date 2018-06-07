using Microsoft.EntityFrameworkCore;
using PracticeSystemPU.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSystemPU.Data
{
    public class PracticeSystemDbContext : DbContext
    {

        public PracticeSystemDbContext()
        {

        }

        public PracticeSystemDbContext(DbContextOptions options)
            : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Firm> Firms { get; set; }
        public DbSet<Practice> Practice { get; set; }
        public DbSet<Internship> Internships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Practice>()
                .HasMany(p => p.Internships)
                .WithOne(i => i.Practice)
                .HasForeignKey(i => i.PracticeId);

            builder.Entity<Firm>()
                .HasMany(f => f.Internships)
                .WithOne(i => i.Firm)
                .HasForeignKey(i => i.FirmId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Internship>()
                .HasMany(i => i.Students)
                .WithOne(s => s.Internship)
                .HasForeignKey(s => s.InternshipId);

            
        }


    }
}