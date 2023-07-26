using AccessGuard_API.Data;
using AccessGuard_API.Models;
using Microsoft.EntityFrameworkCore;

namespace AcessGuard_API.Repositories
{
    public class TenantRepository : ICrud<Tenant>
    {
        private readonly AccessGuardDBContext context;

        public TenantRepository(AccessGuardDBContext context)
        {
            this.context = context;
        }
        public void Add(Tenant entity)
        {
            this.context.Tenants.Add(entity);
        }

        public void Delete(Guid id)
        {
            this.context.Tenants.Remove(Get(id));
        }

        public Tenant Get(Guid id)
        {
            return context.Tenants.Find(id)!;
        }

        public async Task<List<Tenant>> GetAll()
        {
            return await context.Tenants.Include(tenant=>tenant.Locations).ToListAsync();
        }

        public void Update(Tenant entity)
        {
            context.Update(entity);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
