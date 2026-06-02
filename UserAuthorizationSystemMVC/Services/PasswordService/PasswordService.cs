namespace UserAuthorizationSystemMVC.Services.PasswordService
{
    public class PasswordService : IPasswordService
    {
        private readonly string _pepper;

        public PasswordService(IConfiguration config)
        {
            // TODO: replace after debugging
            //_pepper = config["Security:Pepper"]
            //    ?? throw new InvalidOperationException("Missing pepper configuration.");
            _pepper = "hardcoded_to_test";
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
