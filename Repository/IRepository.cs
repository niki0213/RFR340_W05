namespace Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
    }
}