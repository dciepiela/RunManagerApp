using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunManagerWebApp.Data;
using RunManagerWebApp.Data.Interfaces;
using RunManagerWebApp.Models;
using RunManagerWebApp.Repository;
using RunManagerWebApp.ViewModels;

namespace RunManagerWebApp.Controllers
{
    public class ClubController : Controller
    {

        private readonly IClubRepository _clubRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClubController(IClubRepository clubRepository, IHttpContextAccessor httpContextAccessor) 
        {
            //wstrzykiwanie fantazyjne - wprowadzam kontekst bazy danych aplikacji z innej częśći naszego programy
            //_context = context;
            _clubRepository = clubRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        // GET: ClubController
        public async Task<IActionResult> Index() //C
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll();//M
            return View(clubs);//V
        }

        // GET: ClubController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var club = await _clubRepository.GetByIdAsync(id);
            return club == null ? NotFound() : View(club);
        }

        // GET: ClubController/Create
        public IActionResult Create()
        {
            var currentUserID = HttpContext.User.GetUserId();
            var createClubViewModel = new CreateClubViewModel { AppUserId = currentUserID };
            return View(createClubViewModel);
        }

        // POST: ClubController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateClubViewModel clubVM)
        {
            if (ModelState.IsValid)
            {
                var club = new Club
                {
                    Title = clubVM.Title,
                    Description = clubVM.Description,
                    RaceType = clubVM.RaceType,
                    AppUserId = clubVM.AppUserId,
                    Image = clubVM.Image,
                    Address = new Address
                    {
                        Street = clubVM.Address.Street,
                        City = clubVM.Address.City,
                        PostalCode = clubVM.Address.PostalCode
                    }
                };
                _clubRepository.Add(club);
                return RedirectToAction(nameof(Index));
            }
            return View(clubVM);
        }

        // GET: ClubController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }

        // POST: ClubController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, EditClubViewModel clubVM)
        {

            if (ModelState.IsValid)
            {
                var userClub = await _clubRepository.GetByIdAsyncNotTracking(id);
                if (userClub != null)
                {
                    var club = new Club
                    {
                        Id = id,
                        Title = clubVM.Title,
                        Description = clubVM.Description,
                        RaceType = clubVM.RaceType,
                        Image = clubVM.Image,
                        Address = new Address
                        {
                            Street = clubVM.Address.Street,
                            City = clubVM.Address.City,
                            PostalCode = clubVM.Address.PostalCode
                        }
                    };
                    _clubRepository.Update(club);
                    return RedirectToAction("Index");
                }
            }
            return View(clubVM);
        }

        // GET: ClubController/Delete/5
        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {

            var club = await _clubRepository.GetByIdAsync(id);
            return club == null ? NotFound() : View(club);

        }

        // POST: ClubController/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClub(int id)
        { 

            //_clubRepository.Delete2(id);
            // return RedirectToAction(nameof(Index));

            var clubDetails = await _clubRepository.GetByIdAsync(id);
            

            if (clubDetails == null)
            {
                return View("Error");
            }

            _clubRepository.Delete(clubDetails);

            return RedirectToAction("Index");

        }
    }
}
