namespace AcessGuard_API.Models.Entity
{
    public class TenantUser
    {
        public Guid Id { get; set; } = new Guid();
        public string Email { get; set; } = null!;
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdated { get; set; }
        public DateTimeOffset DateLastLogin { get; set; }
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;

        public Tenant Tenant { get; set; } = null!;
        public ICollection<UsersOpenDoors> UsersOpenDoors { get; set; } = null!;
        public ICollection<Logs> LogsUser { get; set; } = null!;
        public ICollection<UserHasRoles> UserHasRoles { get; set; } = null!;
    }
}