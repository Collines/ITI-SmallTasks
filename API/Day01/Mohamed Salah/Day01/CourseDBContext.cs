using Day01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Day01
{
    public class CourseDBContext:DbContext
    {
        public CourseDBContext(DbContextOptions<CourseDBContext> options):base(options)
        {
            
        }

        public virtual DbSet<Course> Courses { get; set; }
    }
}
