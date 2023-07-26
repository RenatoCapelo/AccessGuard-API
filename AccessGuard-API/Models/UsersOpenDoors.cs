namespace AccessGuard_API.Models
{
    public class UsersOpenDoors
    {
        public Guid Id { get; set; } = new Guid();
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }

        public TenantUser User { get; set; } = null!;
        public Door Door { get; set; } = null!;
    }
}
