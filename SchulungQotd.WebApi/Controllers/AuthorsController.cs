using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Service;
using SchulungQotd.Shared.Models;

namespace SchulungQotd.WebApi.Controllers
{
    [Route("api/[controller]")]  // localhost:1234/api/authors
    [ApiController]
    public class AuthorsController(IQotdService qotdService) : ControllerBase
    {
        /// <summary>
        /// Liefert einen zufälligen Spruch Des Tages
        /// </summary>
        /// <returns>QuoteOfTheDay</returns>
        [HttpGet("quotes/qotd")]  // localhost:1234/api/authors/quotes/qotd
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<QuoteOfTheDayViewModel?>> GetQuoteOfTheDayAsync()
        {
            var qotd = await qotdService.GetQuoteOfTheDayAsync();

            if (qotd is null) return NotFound();

            return qotd;
        }
    }
}
