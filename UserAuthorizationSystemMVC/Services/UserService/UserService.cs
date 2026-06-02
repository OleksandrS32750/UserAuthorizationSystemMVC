using UserAuthorizationSystemMVC.Models;
using UserAuthorizationSystemMVC.Services.PasswordService;

namespace UserAuthorizationSystemMVC.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordService _passwordService;



        public UserService(
            IUserRepository repository,
            IPasswordService passwordService)
        {
            _repository = repository;
            _passwordService = passwordService;

            // admin user to test things (only for development)
            Register("admin@gmail.com", "admin_password", "Admin");
        }



        public bool Register(string email, string password,string role="User")
        {
            if (_repository.GetByEmail(email) != null)
                return false;

            AppUser user = new()
            {
                Email = email,
                PasswordHash = _passwordService.HashPassword(password),
                Role=role
            };

            _repository.Add(user);

            return true;
        }

        public AppUser? Login(string email, string password)
        {
            var user = _repository.GetByEmail(email);

            if (user == null)
                return null;

            if (!_passwordService.Verify(password, user.PasswordHash))
                return null;

            return user;
        }

        public AppUser? GetUser(Guid id)
        {
            return _repository.GetById(id);
        }

        public void AddNote(Guid userId, string title, string content)
        {
            var user = _repository.GetById(userId);

            if (user == null)
                return;

            user.Notes.Add(new UserNote
            {
                AppUserId = userId,
                Title = title,
                Content = content
            });
        }
    }
}
