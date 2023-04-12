using Day09;
using Day09.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Day09_remake.Models.Repos
{
    public class TraineCourseRepository : IRepository<TraineeCourse>
    {
        public TraineCourseRepository(MainDBContext context)
        {
            Context = context;
        }

        public MainDBContext Context { get; }

        public void Delete(object ID)
        {
            if(ID != null && ID is TCID id)
            {
                Context.Remove(GetDetails(id));
                Context.SaveChanges();

            }
        }

        public List<TraineeCourse> GetAll()
        {
            return Context.TraineesCourses.Include(T=>T.Course).Include(T=>T.Trainee).ToList();
        }

        public TraineeCourse GetDetails(object ID)
        {
            if (ID != null && ID is TCID id)
                return Context.TraineesCourses.Include(T => T.Course).Include(T => T.Trainee).FirstOrDefault();
            return null;
        }

        public void Insert(TraineeCourse t)
        {
            Context.Add(t);
            Context.SaveChanges();
        }

        public bool isExist(object ID)
        {
            if (ID != null && ID is TCID id)
                return Context.TraineesCourses.Any(TC => TC.TraineeID == id.TraineeID && TC.CourseID == id.CourseID);
            return false;
        }

        public void Update(object ID, TraineeCourse t)
        {
            if (ID != null && ID is TCID id)
            {
                TraineeCourse curr = GetDetails(id);
                if (curr != null)
                {
                    curr.Grade = t.Grade;
                    Context.SaveChanges();
                }
            }
        }
    }
}
