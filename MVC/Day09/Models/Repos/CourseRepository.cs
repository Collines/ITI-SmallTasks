using Day09.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Day09.Models.Repos
{
    public class CourseRepository : IRepository<Course>
    {
        public CourseRepository(MainDBContext context)
        {
            Context = context;
        }

        public MainDBContext Context { get; }

        public void Delete(object ID)
        {
            if(ID != null && ID is int id)
            {
                Course course = Context.Courses.Find(id);
                if (course != null)
                {
                    Context.Courses.Remove(course);
                    Context.SaveChanges();
                }
            }
        }

        public List<Course> GetAll()
        {
            return Context.Courses.ToList();
        }

        public Course GetDetails(object ID)
        {
            if (ID != null && ID is int id)
                return Context.Courses.Find(id);
           return null;
        }

        public void Insert(Course t)
        {
            Context.Add(t);
            Context.SaveChanges();

        }

        public bool isExist(object ID)
        {
            if (ID != null && ID is int id)
                return Context.Courses.Any(C=>C.ID==id);
            return false;
        }

        public void Update(object ID, Course t)
        {
            if (ID != null && ID is int id)
            {
                Course currCourse = Context.Courses.Find(id);
                if (currCourse != null)
                {
                    currCourse.Topic = t.Topic;
                    currCourse.TraineeCourses = t.TraineeCourses;
                    Context.SaveChanges();
                }
            }
        }
    }
}
