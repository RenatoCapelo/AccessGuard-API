using AccessGuard_API.Models;
using AcessGuard_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccessGuard_API.Data
{
    public class AccessGuardDBContext: DbContext
    {
        public AccessGuardDBContext(DbContextOptions<AccessGuardDBContext> options) : base(options)
        {
        }

        public DbSet<Door> Doors { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<Logs> Logs { get; set; } = null!;
        public DbSet<LogType> LogTypes { get; set; } = null!;
        public DbSet<Permission> Permissions { get; set; } = null!;
        public DbSet<RoleHasPermissions> RoleHasPermissions { get; set; } = null!;
        public DbSet<Tenant> Tenants { get; set; } = null!;
        public DbSet<TenantUser> TenantUsers { get; set; } = null!;
        public DbSet<TenantUserRole> TenantUserRoles { get; set; } = null!;
        public DbSet<UserHasRoles> UserHasRoles { get; set; } = null!;
        public DbSet<UsersOpenDoors> UsersOpenDoors { get; set; } = null!;
        public DbSet<Error> Errors { get; set; } = null!;
    }
}
