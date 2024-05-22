using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Mvc.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SchulungMvc.Common.ViewModels;
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
            //TODO: Spruch des Tages erstellen
            var qotd = _context.Quotes.Include(c => c.Author).FirstOrDefault();

            var qotdVm = new QuoteOfTheDayViewModel
            {
                AuthorName = qotd.Author.Name,
                AuthorDescription = qotd.Author.Description,
                AuthorBirthdate = qotd.Author.BirthDate,
                AuthorImage = qotd.Author.Photo,
                AuthorImageMimeType = qotd.Author.PhotoMimeType,
                QuoteText = qotd.QuoteText
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
