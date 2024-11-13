using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Service;

namespace SchulungQotd.Mvc.Controllers;

public class AuthorsController : Controller
{
    private readonly IQotdService _qotdService;

    public AuthorsController(IQotdService qotdService)
    {
        _qotdService = qotdService;
    }

    public IActionResult Index()
    {
        //TODO: Service erweitern , View erstellen
        return View();
    }
}