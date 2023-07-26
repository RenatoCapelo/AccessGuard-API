namespace AccessGuard_API.Models
{
    public class Permission
    {
        public Guid Id { get; set; } = new Guid();
        public string Description { get; set; } = null!;
    }
}