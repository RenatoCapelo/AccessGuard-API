using AcessGuard_API.Models.Dto.Tenant;

namespace AcessGuard_API.Services.Tenants
{
    public interface ITenantService
    {
        public Task<IEnumerable<TenantDto>> GetAll();
        public TenantDto GetById(Guid id, Guid userId);
        public TenantDto Create(TenantToCreateDTO tenantToCreate);
        public TenantDto Update(TenantDto tenantToUpdate);
        public void Delete(Guid id);
    }
}