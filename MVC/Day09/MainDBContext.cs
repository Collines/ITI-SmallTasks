using Microsoft.EntityFrameworkCore;
using Day09.Models;
using Day09_remake.Models;

namespace Day09
{
    public class MainDBContext:DbContext
    {

        public MainDBContext(DbContextOptions<MainDBContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TraineeCourse>().HasKey(TC=> new { TC.TraineeID, TC.CourseID });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Track> Tracks { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<TraineeCourse> TraineesCourses { get; set;}

    }
}
