using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class InstructorRepository : IRepository<Instructor>
    {
        public InstructorRepository(ITIContext db)
        {
            Db = db;
        }

        public ITIContext Db { get; }
        public void Delete(int id)
        {
            Instructor? Inst = Db.Instructors.Find(id);
            if (Inst != null)
            {
                Db.Instructors.Remove(Inst);
                Db.SaveChanges();
            }
        }

        public List<Instructor> GetAll()
        {
            return Db.Instructors.Include(I=>I.Department).ToList();
        }

        public Instructor? GetById(int id)
        {
            return Db.Instructors.Include(I => I.Department).FirstOrDefault(I=>I.Id==id);

        }

        public void Insert(Instructor t)
        {
            if (t != null)
            {
                Db.Add(t);
                Db.SaveChanges();
            }
        }

        public bool isExist(int id)
        {
            return Db.Instructors.Any(I=>I.Id == id);
        }

        public void Update(int id, Instructor t)
        {
            if (t != null)
            {
                Instructor? CurrInt = Db.Instructors.Find(id);
                if(CurrInt != null)
                {
                    CurrInt.Address = t.Address?? CurrInt.Address;
                    CurrInt.Email   = t.Email?? CurrInt.Email;
                    CurrInt.DOB = t.DOB?? CurrInt.DOB;
                    CurrInt.SSN = t.SSN ?? CurrInt.SSN;
                    CurrInt.Salary  = t.Salary??CurrInt.Salary;
                    CurrInt.Age = t.Age ?? CurrInt.Age;
                    CurrInt.Department = t.Department ?? CurrInt.Department;
                    CurrInt.Phone = t.Phone ?? CurrInt.Phone;
                    CurrInt.Password = t.Password ?? CurrInt.Password;
                    CurrInt.Name = t.Name ?? CurrInt.Name;
                    Db.SaveChanges();
                }
            }
        }
    }
}
