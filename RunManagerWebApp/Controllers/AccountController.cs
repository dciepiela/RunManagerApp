using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using RunManagerWebApp.Data;
using RunManagerWebApp.Models;
using RunManagerWebApp.ViewModels;

namespace RunManagerWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,AppDbContext context )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userLoginData)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginData);
            }

            //logika, która loguje
            var user = await _userManager.FindByEmailAsync(userLoginData.Email);
            if(user != null)
            {
                //jeśli użytkownik jest znaleziony, sprawdzamy hasło
                var passwordCheck = await _userManager.CheckPasswordAsync(user, userLoginData.Password);
                if (passwordCheck)
                {
                    //jeśli hasło poprawne, zaloguj się
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginData.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Race");
                    }
                }
                //hasło nieprawidłowe
                TempData["Error"] = "Hasło nieprawidłowe. Spróbuj ponownie";
                return View(userLoginData);
            }
            //użytkownik nie został znalezione
            TempData["Error"] = "Niestety taki użytkownik nie istnieje. Spróbuj ponownie";
            return View(userLoginData);
        }

        [HttpGet]
        public IActionResult Register() 
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userRegisterData) 
        {
            if(!ModelState.IsValid)
            {
                return View(userRegisterData);
            }

            //logika rejestrująca
            var user = await _userManager.FindByEmailAsync(userRegisterData.Email);
            if(user != null)
            {
                TempData["Error"] = "Email już istnieje w naszej bazie";
                return View(userRegisterData);
            }

            var newUser = new AppUser()
            {
                Email = userRegisterData.Email,
                UserName = userRegisterData.Email,
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, userRegisterData.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }

            return RedirectToAction("Index","Race");
        }

        [HttpPost]
        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Race");
        }
    }
}
