using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Service;
using SchulungQotd.Service.Models;

namespace SchulungQotd.Mvc.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IQotdService _qotdService;

        public AuthorsController(IQotdService qotdService)
        {
            _qotdService = qotdService;
        }

        // GET: AuthorsController
        public ActionResult Index()
        {
            var authorsVm = _qotdService.GetAuthors();

            return View(authorsVm);
        }

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorCreateViewModel authorCreateViewModel)
        {
            if (ModelState.IsValid)
            {
               var authorVm = _qotdService.AddAuthorAsync(authorCreateViewModel);

               if (authorVm is not null)
               {
                   return RedirectToAction(nameof(Index));
               }
            }

            return View(authorCreateViewModel);
        }
    }
}
