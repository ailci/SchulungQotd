using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Service;
using SchulungQotd.Shared.Models;
using SchulungQotd.WebApi.Filter;

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
        
        /// <summary>
        /// Liefert einen zufälligen Spruch Des Tages (gesichert)
        /// </summary>
        /// <returns>QuoteOfTheDay</returns>
        [HttpGet("quotes/qotdsecured")]  // localhost:1234/api/authors/quotes/qotdsecured
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [TypeFilter(typeof(ApiKeyAttribute))] // 1. Via Filter
        public async Task<ActionResult<QuoteOfTheDayViewModel?>> GetQuoteOfTheDaySecuredAsync()
        {
            var qotd = await qotdService.GetQuoteOfTheDayAsync();

            if (qotd is null) return NotFound();

            return qotd;
        }

        [HttpGet("{id:guid}", Name = "GetAuthor")]  // localhost:1234/authors/{id}
        public async Task<IActionResult> GetAuthorByIdAsync(Guid id)
        {
            var author = await qotdService.GetAuthorByIdAsync(id);

            if (author is null) return NotFound();

            return Ok(author);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AuthorViewModel>> CreateAuthorAsync(AuthorForCreateViewModel authorForCreateViewModel)
        {
            if (authorForCreateViewModel is null) return BadRequest(ModelState);

            //if (!ModelState.IsValid) return BadRequest(ModelState); //braucht man nicht wenn Controller [ApiController]

            var newAuthorVm = await qotdService.AddAuthorAsync(authorForCreateViewModel);

            if (newAuthorVm is null) return Problem(detail: "Autor konnte nicht erstellt werden", statusCode: 400);

            return CreatedAtRoute("GetAuthor", new { id = newAuthorVm.Id }, newAuthorVm);

            //return Created();
        }

    }
}
