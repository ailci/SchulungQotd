using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Service;

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
    }
}
