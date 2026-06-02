using UserAuthorizationSystemMVC.Models;

namespace UserAuthorizationSystemMVC.Services.UserService
{
    public interface IUserService
    {
        bool Register(string email, string password,string role);

        AppUser? Login(string email, string password);

        AppUser? GetUser(Guid id);

        void AddNote(Guid userId, string title, string content);
    }
}
