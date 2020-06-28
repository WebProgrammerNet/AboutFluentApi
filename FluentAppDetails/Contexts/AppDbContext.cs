using FluentAppDetails.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentAppDetails.Contexts
{
    class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder()
            {
                DataSource= "DESKTOP-NCRI8U1",
                InitialCatalog="fluentapitest",
                IntegratedSecurity = true,
            };

            optionsBuilder.UseSqlServer(sqlConnectionString.ToString());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<Student>().HasKey(r => new { r.PK, r.PK_1 });
            // builder.Entity<Student>().HasIndex(t => t.Email).IsUnique();
            builder.Entity<Student>().Property(r => r.Email).IsRequired()
                .HasMaxLength(50);
            //builder.Entity<Student>().Property<float>(p => p.GPA);
            builder.Entity<Student>().Property<float>("GPA");
            base.OnModelCreating(builder);
        }

    }
}
