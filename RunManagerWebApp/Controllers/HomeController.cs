using ExternalViewComponents.Models.Meta;
using Microsoft.AspNetCore.Mvc;
using RunManagerWebApp.Models;
using System.Diagnostics;

namespace RunManagerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["MetaTags"] = new MetaTags
            {
                Description = "Zarządzanie zawodami i klubami",
                Title = "Run Manager",
                Keywords = "sport,running,athletes,run,biegi",
                Language = "pl-PL"
            };
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}