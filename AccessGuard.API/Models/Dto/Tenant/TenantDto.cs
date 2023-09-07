using AccessGuard_API.Models.Entity;

namespace AccessGuard_API.Models.Dto.Tenant
{
    public class TenantDto
    {
        public Guid Id { get; set; }
        public string TenantName { get; set; } = null!;

    }
}
