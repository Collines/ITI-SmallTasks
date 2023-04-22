using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ITIContext:DbContext
    {
        public ITIContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }
}
