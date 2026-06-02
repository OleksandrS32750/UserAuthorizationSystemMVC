namespace UserAuthorizationSystemMVC.Models
{
    public class AppUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = "User"; // will be 2 roles ["User","Admin"],by default each user has only "User" rights

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<UserNote> Notes { get; set; } = new();
    }
}
