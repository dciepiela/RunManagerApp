using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunManagerWebApp.Data.Interfaces;
using RunManagerWebApp.Models;
using RunManagerWebApp.Repository;
using RunManagerWebApp.ViewModels;

namespace RunManagerWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;

        public UserController(IUserRepository userRepository, UserManager<AppUser> userManager)
        {
            _userRepository= userRepository;
            _userManager= userManager;
        }

        [HttpGet("użytkownicy")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach(var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Pace = user.Pace,
                    Mileage = user.Milage,
                    City = user.City,
                    PostalCode = user.PostalCode,
                    ProfileImage = user.ProfileImage
                };
                result.Add(userViewModel);
            }
            return View(result);
        }

        public async Task<IActionResult> Details(string id)
        {
            var user =  await _userRepository.GetUserById(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Pace = user.Pace,
                Mileage = user.Milage,
                City = user.City,
                PostalCode = user.PostalCode,
                ProfileImage = user.ProfileImage
            };
            return View(userDetailViewModel);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditUserProfile()
        {
            //var currentUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return View("Error");
            var editVM = new EditUserViewModel()
            {
                Pace = user.Pace,
                Mileage = user.Milage,
                City = user.City,
                PostalCode = user.PostalCode,
                ProfileImage = user.ProfileImage,
            };
            return View(editVM);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditUserProfile(EditUserViewModel editVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.GetUserAsync(User);

                //update fields
                user.Pace = editVM.Pace;
                user.Milage = editVM.Mileage;
                user.ProfileImage = editVM.ProfileImage;
                user.City = editVM.City;
                user.PostalCode = editVM.PostalCode;

                await _userManager.GetUserAsync(User);
                return RedirectToAction("Index");
            }
            return View(editVM);
        }
    }
}
