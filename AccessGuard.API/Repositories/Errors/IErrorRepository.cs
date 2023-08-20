using AcessGuard_API.Models.Entity;

namespace AcessGuard_API.Repositories.Errors
{
    public interface IErrorRepository
    {
        Error? GetError(string Id);
        Task<IEnumerable<Error>> GetErrors();
        void CreateError(Error entity);
        void UpdateError(Error entity);
        void DeleteError(Error entity);
        void SaveChanges();
    }
}
