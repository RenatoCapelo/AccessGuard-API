namespace AccessGuard_API.Models
{
    public class TenantUserRole
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;

        public ICollection<UserHasRoles> UserHasRoles { get; set; } = null!;
        public ICollection<RoleHasPermissions> RoleHasPermissions { get; set; } = null!;
    }
}