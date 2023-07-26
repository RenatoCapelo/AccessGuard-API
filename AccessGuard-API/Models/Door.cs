namespace AccessGuard_API.Models
{
    public class Door
    {
        public Guid Id { get; set; } = new Guid();
        public string Description { get; set; } = null!;

        public Location Location { get; set; } = null!;
    }
}
