using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Mvc.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SchulungQotd.Data.Context;
using SchulungQotd.Domain;

namespace SchulungQotd.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QotdContext _context;

        public HomeController(ILogger<HomeController> logger, QotdContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var quotes = _context.Quotes.Include(c => c.Author).ToList();
            var random = new Random();

            var randomQuote = quotes[random.Next(0, quotes.Count)];  //6,1,3,9,7

            var qotd = new QuoteOfTheDayViewModel
            {
                QuoteText = randomQuote.QuoteText,
                AuthorName = randomQuote.Author?.Name ?? string.Empty,
                AuthorDescription = randomQuote.Author?.Description ?? string.Empty,
                AuthorBirthdate = randomQuote.Author?.BirthDate,
                AuthorImage = randomQuote.Author?.Photo,
                AuthorMimeType = randomQuote.Author?.PhotoMimeType
            };

            return View(qotd);
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
