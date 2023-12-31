﻿using AccessGuard_API.Data;
using AccessGuard_API.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace AccessGuard_API.Repositories.Errors
{
    public class ErrorRepository : IErrorRepository
    {
        private readonly AccessGuardDBContext _dbContext;
        public ErrorRepository(AccessGuardDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async void CreateError(Error entity)
        {
            await _dbContext.Errors.AddAsync(entity);
        }

        public void DeleteError(Error entity)
        {
            _dbContext.Errors.Remove(entity);
        }


        public Error? GetError(string Id)
        {
            return _dbContext.Errors.Find(Id);
        }

        public async Task<IEnumerable<Error>> GetErrors(int page=1, int pageSize = 25)
        {
            return await _dbContext.Errors.Skip(pageSize*(page-1)).Take(pageSize).ToListAsync();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateError(Error entity)
        {
            _dbContext.Errors.Update(entity);
        }

        public int Count()
        {
            return _dbContext.Errors.Count();
        }
    }
}
