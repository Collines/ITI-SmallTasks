using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T>
    {
        public List<T>? GetAll();
        public T? GetById(int id);
        public void Insert(T t);
        public void Update(int id, T t);
        public void Delete(int id);
        public bool isExist(int id);
    }
}
