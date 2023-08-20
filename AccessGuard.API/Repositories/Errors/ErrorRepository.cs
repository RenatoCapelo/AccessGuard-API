using AccessGuard_API.Data;
using AcessGuard_API.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace AcessGuard_API.Repositories.Errors
{
    public class ErrorRepository : IErrorRepository
    {
        private readonly AccessGuardDBContext _dbContext;
        public ErrorRepository(AccessGuardDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateError(Error entity)
        {
            _dbContext.Errors.Add(entity);
        }

        public void DeleteError(Error entity)
        {
            _dbContext.Errors.Remove(entity);
        }


        public Error? GetError(string Id)
        {
            return _dbContext.Errors.Find(Id);
        }

        public async Task<IEnumerable<Error>> GetErrors()
        {
            return await _dbContext.Errors.ToListAsync();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateError(Error entity)
        {
            _dbContext.Errors.Update(entity);
        }
    }
}
