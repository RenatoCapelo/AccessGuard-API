using AccessGuard_API.Models.Entity;

namespace AccessGuard_API.Repositories.Tenants
{
    public interface ITenantRepository
    {
        Tenant? Get(Guid id);
        Task<List<Tenant>> GetAll(int page = 1, int pageSize = 25);
        void Add(Tenant entity);
        void Update(Tenant entity);
        void Delete(Tenant entity);
        void SaveChanges();
        int Count();
    }
}
