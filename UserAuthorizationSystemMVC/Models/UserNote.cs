namespace UserAuthorizationSystemMVC.Models
{
    public class UserNote
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid AppUserId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
