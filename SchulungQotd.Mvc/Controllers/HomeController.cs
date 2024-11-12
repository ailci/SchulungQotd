using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Mvc.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SchulungQotd.Domain;
using SchulungQotd.Shared.Models;
using SchulungQotd.Data.Context;

namespace SchulungQotd.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QotdContext _qotdContext;

        public HomeController(ILogger<HomeController> logger, QotdContext qotdContext)
        {
            _logger = logger;
            _qotdContext = qotdContext;
        }

        public IActionResult Index()
        {
            ViewBag.Message = DateTime.Now.Hour > 12 ? "Guten Tag" : "Guten Morgen";

            var author = _qotdContext.Authors.Include(c => c.Quotes).FirstOrDefault();

            var qotdVm = new QuoteOfTheDayViewModel()
            {
                AuthorName = author.Name,
                AuthorDescription = author.Description,
                AuthorBirthDate = author.BirthDate,
                QuoteText = author.Quotes.FirstOrDefault().QuoteText
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
