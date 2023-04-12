using Day09.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Day09.Models.Repos
{
    public class TraineeRepository : IRepository<Trainee>
    {
        public TraineeRepository(MainDBContext context)
        {
            Context = context;
        }

        public MainDBContext Context { get; }

        public void Delete(object ID)
        {
            if (ID != null && ID is int id)
            {
                Context.Remove(GetDetails(id));
                Context.SaveChanges();
            }
        }

        public List<Trainee> GetAll()
        {
            return Context.Trainees.ToList();
        }

        public Trainee GetDetails(object ID)
        {
            if (ID != null && ID is int id)
                return Context.Trainees.Find(id);
            return null;
        }

        public void Insert(Trainee t)
        {
            Context.Add(t);
            Context.SaveChanges();
        }

        public bool isExist(object ID)
        {
            if (ID != null && ID is int id)
                return Context.Trainees.Any(T=>T.ID== id);
            return false;
        }

        public void Update(object ID, Trainee t)
        {
            if (ID != null && ID is int id)
            {
                Trainee currTrainee = Context.Trainees.Find(id);
                if (currTrainee != null)
                {
                    currTrainee.Track = t.Track;
                    currTrainee.Email = t.Email;
                    currTrainee.Birthdate = t.Birthdate;
                    currTrainee.Name = t.Name;
                    currTrainee.TraineeCourses = t.TraineeCourses;
                    currTrainee.Phone = t.Phone;
                    currTrainee.Gender = t.Gender;
                    Context.SaveChanges();
                }
            }
                
        }
    }
}
