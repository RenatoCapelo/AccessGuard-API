using AccessGuard_API.Models.Entity;

namespace AccessGuard_API.Repositories.Errors
{
    public interface IErrorRepository
    {
        Error? GetError(string Id);
        Task<IEnumerable<Error>> GetErrors(int page = 1, int pageSize = 25);
        void CreateError(Error entity);
        void UpdateError(Error entity);
        void DeleteError(Error entity);
        void SaveChanges();
        int Count();
    }
}
