namespace AccessGuard_API.Models.Entity
{
    public class Tenant
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TenantName { get; set; } = null!;

        public ICollection<Location>? Locations { get; set; }
        public ICollection<TenantUser>? TenantUsers { get; set; }
    }
}
