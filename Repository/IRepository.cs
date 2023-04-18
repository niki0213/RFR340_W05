using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        IEnumerable<T> ReadAll();
    }
}