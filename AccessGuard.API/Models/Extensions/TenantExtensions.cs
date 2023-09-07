using AccessGuard_API.Models.Dto.Tenant;
using AccessGuard_API.Models.Entity;

namespace AccessGuard_API.Models.Extensions
{
    public static class TenantExtensions
    {
        public static TenantDto ToDto(this TenantToCreateDTO tenant)
        {
            return new TenantDto() { TenantName = tenant.TenantName };
        }
        public static TenantDto ToDto(this Tenant entity)
        {
            return new TenantDto() { Id = entity.Id, TenantName = entity.TenantName };
        }


        public static Tenant ToEntity(this TenantDto tenant)
        {
            return new Tenant() { Id = tenant.Id, TenantName = tenant.TenantName };
        }

    }
}
