using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected List<T> items;
        public Repository(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }
        public void Add(T item)
        {
            items.Add(item);
        }
        public IEnumerable<T> ReadAll()
        {
            return items;
        }
    }
}
