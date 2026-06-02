namespace UserAuthorizationSystemMVC.Services.PasswordService
{
    public class PasswordService : IPasswordService
    {
        private readonly string _pepper;

        public PasswordService(IConfiguration config)
        {
            _pepper = config["Security:Pepper"]
                ?? throw new InvalidOperationException("Missing pepper configuration.");
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password + _pepper, workFactor: 12);
        }

        public bool Verify(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password + _pepper, storedHash);
        }
    }
}
