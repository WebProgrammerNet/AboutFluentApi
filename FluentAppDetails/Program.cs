using FluentAppDetails.Contexts;
using FluentAppDetails.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentAppDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var _db = new AppDbContext())
            {
                var flag = _db.Database.EnsureCreated();
                if(flag)
                {
                    _db.Students.Add(new Student() { Name = "Alim", Email = "alim@mail.ru", GPA = 2.2f });
                    _db.Students.Add(new Student() { Name = "Azim", Email = "azim@mail.ru", GPA = 2.6f });
                    _db.Students.Add(new Student() { Name = "Aziz", Email = "aziz@mail.ru", GPA = 3.2f });
                    _db.Students.Add(new Student() { Name = "Hakim", Email = "hakim@mail.ru", GPA = 2.5f });
                    _db.SaveChanges();

                    _db.Courses.Add(new Course() { Name = "Pattern", StudentFK = 13 });
                    _db.Courses.Add(new Course() { Name = "SW", StudentFK = 13 });
                    _db.Courses.Add(new Course() { Name = "English", StudentFK = 14 });
                    _db.SaveChanges();
                }

                  List<Student> students = _db.Students.Include(t => t.Courses).ToList();

                  Student Alim = _db.Students.Find(13);
                  _db.Entry(Alim).Collection(c => c.Courses).Load();

                foreach (var item in students)
                {
                    Console.WriteLine(
                        _db.Entry(item)
                        .Property<float>("GPA").CurrentValue
                        );
                }


                var list = _db.Students.OrderBy(w => EF.Property<float>(w, "GPA")).ToList();
                foreach (var item in list)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(_db.Entry(item).Property<float>("GPA").CurrentValue);
                }
            }
        }
    }
}
