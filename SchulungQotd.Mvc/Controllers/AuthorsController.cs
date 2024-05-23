using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Service;

namespace SchulungQotd.Mvc.Controllers
{
    public class AuthorsController(ILogger<AuthorsController> logger, IQotdService qotdService) : Controller
    {
        #region GET

        /// <summary>
        /// Gets all authors
        /// </summary>
        /// <returns>authors</returns>
        public async Task<IActionResult> Index()
        {
            var authorsVm = await qotdService.GetAuthorsAsync();
            
            logger.LogInformation($"Authors vom Service: {JsonSerializer.Serialize(authorsVm, new JsonSerializerOptions {WriteIndented = true})}");

            return View(authorsVm);
        }

        public async Task<IActionResult> GetImage(Guid authorId)
        {
            var author = await qotdService.GetAuthorByIdAsync(authorId);

            return author?.PhotoMimeType is not null
                ? new FileContentResult(author.Photo!, author.PhotoMimeType)
                : new VirtualFileResult("~/images/noimg.jpg", System.Net.Mime.MediaTypeNames.Image.Jpeg);
        }

        #endregion
    }
}
