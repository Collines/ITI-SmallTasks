using System.Collections.Generic;

namespace Day09.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T GetDetails(object id);
        public void Insert(T t);
        public void Update(object id,T t);
        public void Delete(object id);
        public bool isExist(object id);
    }
}
