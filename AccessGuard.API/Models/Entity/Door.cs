namespace AcessGuard_API.Models.Entity
{
    public class Door
    {
        public Guid Id { get; set; } = new Guid();
        public string Description { get; set; } = null!;

        public Location Location { get; set; } = null!;
    }
}
