using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using TestTask.Business.Interfaces;
using TestTask.Business.Models;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private static readonly string cookie = "ApplicationCookie";
        private static readonly string errorMessage = "Неверный логин или пароль.";

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserData userDto = new UserData { Email = model.Email, Password = model.Password };

                var user = await _userService.LoginAsync(userDto);

                if (user == null)
                {
                    ModelState.AddModelError("", errorMessage);
                }
                else
                {
                    await Authenticate(user.Email);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        private async Task Authenticate(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, cookie, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserData userDto = new UserData
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                };

                var user = await _userService.RegisterAsync(userDto);
                await Authenticate(user.Email);

                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.AddModelError("", errorMessage);

            return View(model);
        }
    }
}
