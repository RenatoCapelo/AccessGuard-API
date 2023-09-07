using AccessGuard_API.Models.Dto.Other;
using AccessGuard_API.Models.Dto.Tenant;

namespace AccessGuard_API.Services.Tenants
{
    public interface ITenantService
    {
        public Task<Paginator<TenantDto>> GetAll(int page = 1, int pageSize = 25);
        public TenantDto Get(Guid id);
        public TenantDto Create(TenantToCreateDTO tenantToCreate);
        public TenantDto Update(TenantDto tenantToUpdate);
        public void Delete(Guid id);
    }
}