using Microsoft.AspNetCore.Mvc;
using RunManagerWebApp.Data;
using RunManagerWebApp.Data.Interfaces;
using RunManagerWebApp.Models;

namespace RunManagerWebApp.ViewComponents
{
    public class TopRace:ViewComponent
    {
        private readonly IRaceRepository _raceRepository;
        public TopRace(IRaceRepository raceRepository)
        {
            _raceRepository= raceRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync(int numberToTake)
        {
            var mostPopular = await _raceRepository.GetTopRacesAsync(numberToTake);
            return View(mostPopular);
        }
    }
}
