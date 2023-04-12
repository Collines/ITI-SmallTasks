using Day09.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Day09.Models.Repos
{
    public class TrackRepository : IRepository<Track>
    {
        public TrackRepository(MainDBContext context)
        {
            Context = context;
        }

        public MainDBContext Context { get; }

        public void Delete(object ID)
        {
            if (ID != null && ID is int id)
            {
                Context.Tracks.Remove(GetDetails(id));
                Context.SaveChanges();
            }
                
        }

        public List<Track> GetAll()
        {
            return Context.Tracks.ToList();
        }

        public Track GetDetails(object ID)
        {
            if (ID != null && ID is int id)
                return Context.Tracks.Find(id);
            return null;
        }

        public void Insert(Track t)
        {
            Context.Add(t);
            Context.SaveChanges();
        }

        public bool isExist(object ID)
        {
            if (ID != null && ID is int id)
                return Context.Tracks.Any(T=>T.ID==id);
            return false;
        }

        public void Update(object ID, Track t)
        {
            if (ID != null && ID is int id)
            {
                Track currTrack = Context.Tracks.Find(id);
                if (currTrack != null)
                {
                    currTrack.Name = t.Name;
                    currTrack.Description = t.Description;
                    currTrack.Trainees = t.Trainees;
                    Context.SaveChanges();
                }
            }
               
        }
    }
}
