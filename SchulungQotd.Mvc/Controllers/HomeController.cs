using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Mvc.Models;
using System.Diagnostics;
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
            var quotes = _context.Quotes.ToList();



            var qotdVm = new QuoteOfTheDayViewModel
            {
                AuthorName = "Ali Ilci",
                QuoteText = "Larum lierum Löffelstiel, wer nicht fragt, der weiß nicht viel.",
                AuthorDescription = "Dozent",
                AuthorBirthdate = DateOnly.FromDateTime(new DateTime(1978, 07, 13)),
                AuthorImage = null,
                AuthorImageMimeType = null
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
