namespace AccessGuard_API.Models
{
    public class Tenant
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TenantName { get; set; } = null!;

        public ICollection<Location>? Locations { get; set; }
    }
}
