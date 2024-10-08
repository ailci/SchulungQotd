using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchulungQotd.Mvc.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: AuthorsController
        public ActionResult Index()
        {
            return View();
        }
    }
}
