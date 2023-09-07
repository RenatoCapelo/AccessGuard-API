using AccessGuard_API.Data;
using AccessGuard_API.Exceptions;
using AccessGuard_API.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace AccessGuard_API.Repositories.Tenants
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AccessGuardDBContext context;

        public TenantRepository(AccessGuardDBContext context)
        {
            this.context = context;
        }
        public void Add(Tenant entity)
        {
            context.Tenants.Add(entity);
        }

        public void Delete(Tenant entity)
        {
            context.Tenants.Remove(entity);
        }

        public Tenant? Get(Guid id)
        {
            return context.Tenants.Find(id);
        }

        public async Task<List<Tenant>> GetAll(int page = 1, int pageSize = 25)
        {
            return await context.Tenants.Skip(pageSize*(page-1)).Take(pageSize).ToListAsync();
        }

        public void Update(Tenant entity)
        {
            context.Update(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public int Count() { 
            return context.Tenants.Count();
        }

    }
}
