using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Mvc.Models;
using System.Diagnostics;
using SchulungQotd.Domain;
using SchulungQotd.Shared.Models;

namespace SchulungQotd.Mvc.Controllers
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
            ViewBag.Message = DateTime.Now.Hour > 12 ? "Guten Tag" : "Guten Morgen";

            var qotdVm = new QuoteOfTheDayViewModel()
            {
                AuthorName = "Darth Vader",
                AuthorDescription = "Sith-Lord",
                AuthorBirthDate = DateOnly.FromDateTime(new DateTime(1977, 04, 05)),
                QuoteText = "Sie machen mich enttäuscht, Commander!"
            };

            return View(qotdVm);
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
