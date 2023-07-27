namespace AcessGuard_API.Models.Entity
{
    public class TenantUserRole
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;

        public ICollection<UserHasRoles> UserHasRoles { get; set; } = null!;
        public ICollection<RoleHasPermissions> RoleHasPermissions { get; set; } = null!;
    }
}