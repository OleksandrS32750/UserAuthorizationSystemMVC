using UserAuthorizationSystemMVC.Models;

namespace UserAuthorizationSystemMVC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<AppUser> _users = new();


        public void Add(AppUser user)
        {
            _users.Add(user);
        }

        public AppUser? GetByEmail(string email)
        {
            return _users.FirstOrDefault(x =>
                x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public AppUser? GetById(Guid id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AppUser> GetAll()
        {
            return _users;
        }
    }
}
