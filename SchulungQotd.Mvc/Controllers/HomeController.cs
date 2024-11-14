using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Mvc.Models;
using System.Diagnostics;
using System.Text.Json;
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
        private readonly IHttpClientFactory _httpFactory;

        public HomeController(ILogger<HomeController> logger, IQotdService qotdService, 
            IHttpClientFactory httpFactory)
        {
            _logger = logger;
            _qotdService = qotdService;
            _httpFactory = httpFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Message = DateTime.Now.Hour > 12 ? "Guten Tag" : "Guten Morgen";

            var qotdVm = await _qotdService.GetQuoteOfTheDayAsync();

            return View(qotdVm);
        }

        public async Task<IActionResult> IndexWithApi()
        {
            // 1. Version mit HttpClient
            //var client = new HttpClient();
            //var response = await client.GetAsync("https://localhost:7256/api/Authors/quotes/qotd");

            // 2. Version mit HttpClientFactory
            //var client = _httpFactory.CreateClient("qotdapi");
            //var response = await client.GetAsync("api/Authors/quotes/qotd");

            //if (response.IsSuccessStatusCode)
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    var qotd = JsonSerializer.Deserialize<QuoteOfTheDayViewModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
            //    return View("Index", qotd);
            //}

            // 3. Abkürzung
            var client = _httpFactory.CreateClient("qotdapi");
            var qotd = await client.GetFromJsonAsync<QuoteOfTheDayViewModel>("api/Authors/quotes/qotd");
            return View("Index",qotd);

            //return Empty;
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
