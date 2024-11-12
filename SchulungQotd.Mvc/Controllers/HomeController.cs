using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Mvc.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SchulungQotd.Domain;
using SchulungQotd.Shared.Models;
using SchulungQotd.Data.Context;
using SchulungQotd.Service;

namespace SchulungQotd.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQotdService _qotdService;

        public HomeController(ILogger<HomeController> logger, IQotdService qotdService)
        {
            _logger = logger;
            _qotdService = qotdService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Message = DateTime.Now.Hour > 12 ? "Guten Tag" : "Guten Morgen";

            var qotdVm = await _qotdService.GetQuoteOfTheDayAsync();

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
