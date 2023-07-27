namespace AcessGuard_API.Models.Entity
{
    public class Permission
    {
        public Guid Id { get; set; } = new Guid();
        public string Description { get; set; } = null!;
    }
}