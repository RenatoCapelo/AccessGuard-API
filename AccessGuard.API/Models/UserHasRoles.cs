namespace AccessGuard_API.Models
{
    public class UserHasRoles
    {
        public Guid Id { get; set; } = new Guid();

        public TenantUser User { get; set; } = null!;
        public TenantUserRole Role { get; set; } = null!;
    }
}