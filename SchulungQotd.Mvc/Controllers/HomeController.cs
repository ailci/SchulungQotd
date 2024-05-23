using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Mvc.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SchulungMvc.Common.ViewModels;
using SchulungQotd.Data.Context;
using SchulungQotd.Domain;
using SchulungQotd.Service;

namespace SchulungQotd.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQotdService _qotdService;
        private readonly IQotdService _fakeQotdService;

        public HomeController(ILogger<HomeController> logger, IQotdService qotdService, 
            [FromKeyedServices("fakeService")] IQotdService fakeQotdService)
        {
            _logger = logger;
            _qotdService = qotdService;
            _fakeQotdService = fakeQotdService;
        }

        public async Task<IActionResult> Index()
        {
            var qotdVm = await _qotdService.GetQuoteOfTheDayAsync();
            
            return View(qotdVm);
        }

        public async Task<IActionResult> IndexFake()
        {
            var qotdVm = await _fakeQotdService.GetQuoteOfTheDayAsync();

            return View("Index",qotdVm);
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
