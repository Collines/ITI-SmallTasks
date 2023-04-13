using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Day08_Task2.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;

    public class StudentCourseDBContext : DbContext
{
    public StudentCourseDBContext (DbContextOptions<StudentCourseDBContext> options) : base (options)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Data Source=DESKTOP-VREBPAN\\MSSQLSERVER17;Initial Catalog=StudentCourse;Integrated Security=True;Encrypt=false;");

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        optionsBuilder.UseSqlServer("Data Source=DESKTOP-VREBPAN\\MSSQLSERVER17;Initial Catalog=StudentCourse;Integrated Security=True;Encrypt=false;");
    //    }
    //}
    public DbSet<Day08_Task2.Models.Course> Course { get; set; }
    public DbSet<Day08_Task2.Models.Student> Student { get; set; }
}
