namespace AcessGuard_API.Repositories
{
    public interface ICrud<T>
    {
        T Get(Guid id);
        Task<List<T>> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        void SaveChanges();
    }
}
