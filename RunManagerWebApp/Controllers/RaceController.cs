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
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;

        public RaceController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }
        // GET: RaceController
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRepository.GetAll();//M
            return View(races);//V
        }

        // GET: RaceController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Race race = await _raceRepository.GetByIdAsync(id);
            return race == null ? NotFound() : View(race);
        }

        // GET: RaceController/Create
        public IActionResult Create()
        {
            var currentUserID = HttpContext.User.GetUserId();
            var createRaceViewModel = new CreateRaceViewModel { AppUserId = currentUserID };
            return View(createRaceViewModel);
        }

        // POST: RaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRaceViewModel raceVM)
        {
            if (ModelState.IsValid)
            {
                var race = new Race
                {
                    Title = raceVM.Title,
                    Description = raceVM.Description,
                    RaceType = raceVM.RaceType,
                    RaceDate = raceVM.RaceDate,
                    RaceDistance= raceVM.RaceDistance,
                    AppUserId = raceVM.AppUserId,
                    Image = raceVM.Image,
                    Address = new Address
                    {
                        Street = raceVM.Address.Street,
                        City = raceVM.Address.City,
                        PostalCode = raceVM.Address.PostalCode
                    }
                };
                _raceRepository.Add(race);
                return RedirectToAction(nameof(Index));
            }
            return View(raceVM);

        }

        // GET: RaceController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var race = await _raceRepository.GetByIdAsync(id);
            return View(race);
        }

        // POST: RaceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditRaceViewModel raceVM)
        {
            if (ModelState.IsValid)
            {
                var userRace = await _raceRepository.GetByIdAsyncNotTracking(id);
                if (userRace != null)
                {
                    var race = new Race
                    {
                        Id = id,
                        Title = raceVM.Title,
                        Description = raceVM.Description,
                        RaceType = raceVM.RaceType,
                        RaceDate = raceVM.RaceDate,
                        RaceDistance = raceVM.RaceDistance,
                        //AppUserId = raceVM.AppUserId,
                        Image = raceVM.Image,
                        Address = new Address
                        {
                            Street = raceVM.Address.Street,
                            City = raceVM.Address.City,
                            PostalCode = raceVM.Address.PostalCode
                        }
                    };
                    _raceRepository.Update(race);
                    return RedirectToAction("Index");
                }
            }
            return View(raceVM);
        }

        // GET: RaceController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var raceDetails = await _raceRepository.GetByIdAsync(id);
            return raceDetails == null ? NotFound() : View(raceDetails);
        }

        // POST: ClubController/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteRace(int id)
        {
            var raceDetails = await _raceRepository.GetByIdAsync(id);
            if (raceDetails == null)
            {
                return View("Error");
            }

            _raceRepository.Delete(raceDetails);
            return RedirectToAction(nameof(Index));
        }
    }
}
