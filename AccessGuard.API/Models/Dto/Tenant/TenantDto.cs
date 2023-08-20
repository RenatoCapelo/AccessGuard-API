using AccessGuard_API.Models.Entity;

namespace AccessGuard_API.Models.Dto.Tenant
{
    public class TenantDto
    {
        public Guid Id { get; set; }
        public string TenantName { get; set; } = null!;

        public TenantDto()
        {
            
        }
        public TenantDto(Guid id, string tenantName)
        {
            Id = id;
            TenantName = tenantName;
        }

        public TenantDto(Entity.Tenant tenant)
        {
            this.Id = tenant.Id;
            this.TenantName = tenant.TenantName;
        }

        public Entity.Tenant ConvertToEntity() {
            return new Entity.Tenant() { Id = Id, TenantName = TenantName};        
        }
    }
}
