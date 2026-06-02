using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using UserAuthorizationSystemMVC.Models;
using UserAuthorizationSystemMVC.Services.UserService;

namespace UserAuthorizationSystemMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {

            // add that admin user can change role (check authz before)
            var created = _userService.Register(registerViewModel.Email, registerViewModel.Password,"User");

            if (created)
            {
                var user = _userService.Login(registerViewModel.Email, registerViewModel.Password);

                ViewBag.source = "User succesfully created and logined" + user.Email;
                return View("Login");
            }

            // make more clear validation later
            ViewBag.Error = "Password or Email are wrong";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var user = _userService.Login(loginViewModel.Email, loginViewModel.Password);

            if (user is null)
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }

            ViewBag.source = "ViewBagTest : user email is " + user.Email;
            return View("Dashboard",user);
        }
    }
}
