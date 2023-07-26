namespace AccessGuard_API.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;

        public Tenant Tenant { get; set; } = null!;
        public ICollection<Door> Doors { get; set; } = null!;
    }
}
