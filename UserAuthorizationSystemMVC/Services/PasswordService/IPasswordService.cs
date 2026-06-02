namespace UserAuthorizationSystemMVC.Services.PasswordService
{
    public interface IPasswordService
    {
        string HashPassword(string password);

        bool Verify(string password, string storedHash);
    }
}
