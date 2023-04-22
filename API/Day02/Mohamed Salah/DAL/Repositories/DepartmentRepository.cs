using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        public DepartmentRepository(ITIContext db)
        {
            Db = db;
        }

        public ITIContext Db { get; }

        public void Delete(int id)
        {
            Department? Dep = Db.Departments.Find(id);
            if(Dep != null) {
                Db.Departments.Remove(Dep);
                Db.SaveChanges();
            }
        }

        public List<Department> GetAll()
        {
            return Db.Departments.ToList();
        }

        public Department? GetById(int id)
        {
            return Db.Departments.Find(id);
        }

        public void Insert(Department t)
        {
            if(t!=null)
            {
                Db.Add(t);
                Db.SaveChanges();
            }
        }

        public bool isExist(int id)
        {
            return Db.Departments.Any(d=>d.Id==id);
        }

        public void Update(int id, Department t)
        {
            if(t != null)
            {
                Department? CurrDep = Db.Departments.Find(id);
                if(CurrDep!=null)
                {
                    CurrDep.Branches = t.Branches;
                    CurrDep.Instructors = t.Instructors;
                    CurrDep.Location = t.Location;
                    CurrDep.Description = t.Description;
                    CurrDep.Name = t.Name;
                    Db.SaveChanges();
                }
            }
        }
    }
}
