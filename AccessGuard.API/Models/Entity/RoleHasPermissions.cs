namespace AccessGuard_API.Models.Entity
{
    public class RoleHasPermissions
    {
        public Guid Id { get; set; } = new Guid();

        public TenantUserRole Role { get; set; } = null!;
        public Permission Permission { get; set; } = null!;
    }
}