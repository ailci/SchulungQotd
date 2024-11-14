using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchulungQotd.WebApi.Controllers
{
    [Route("api/[controller]")]  // localhost:1234/api/authors
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        [HttpGet]  // localhost:1234/api/authors
        public IActionResult GetQuoteOfTheDayAsync()
        {
            return Ok("hallo api");
        }
    }
}
