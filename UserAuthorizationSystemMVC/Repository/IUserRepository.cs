using UserAuthorizationSystemMVC.Models;

public interface IUserRepository
{
    AppUser? GetByEmail(string email);

    AppUser? GetById(Guid id);

    void Add(AppUser user);

    IEnumerable<AppUser> GetAll();
}