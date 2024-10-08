using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Mvc.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SchulungQotd.Data.Context;
using SchulungQotd.Domain;
using SchulungQotd.Service;
using SchulungQotd.Service.Models;

namespace SchulungQotd.Mvc.Controllers
{
    public interface IBier
    {
        string HolBier();
    }

    public class Krombacher : IBier
    {
        public string HolBier()
        {
            return "Krombacher";
        }

        public string Test()
        {
            return string.Empty;
        }
    }

    public class Veltins : IBier
    {
        public string HolBier()
        {
            return "Veltins";
        }
    }


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQotdService _qotdService;

        public HomeController(ILogger<HomeController> logger, QotdContext context, IQotdService qotdService)
        {
            _logger = logger;
            _qotdService = qotdService;
        }

        public IActionResult Index()
        {
            var qotd = _qotdService.GetQuoteOfTheDay();

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
