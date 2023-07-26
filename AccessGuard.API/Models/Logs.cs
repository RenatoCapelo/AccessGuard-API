namespace AccessGuard_API.Models
{
    public class Logs
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = null!;
        public string Level { get; set; } = null!;
        public DateTimeOffset Timestamp { get; set; }

        public TenantUser User { get; set; } = null!;
        public LogType LogType { get; set; } = null!;
    }
}