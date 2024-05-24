using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SchulungMvc.Common.ViewModels;
using SchulungQotd.Domain;
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

        public async Task<IActionResult> Details(Guid id)
        {
            logger.LogInformation($"Details mit Author-Id: {id} aufgerufen...");
            var author = await qotdService.GetAuthorByIdAsync(id, true);
            return View(author);
        }

        #endregion

        #region DELETE

        public async Task<IActionResult> Delete(Guid id)
        {
            logger.LogInformation($"Delete mit Author-Id: {id} aufgerufen...");
            return View(await qotdService.GetAuthorByIdAsync(id));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var deletedAuthorVm = await qotdService.DeleteAuthorAsync(id);

            if (deletedAuthorVm is not null)
            {
                //Weiterleiten
                return RedirectToAction(nameof(Index));
            }

            return View(deletedAuthorVm);
        }

        #endregion

        #region CREATE

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(AuthorCreateViewModel authorCreateVm)
        {
            if (ModelState.IsValid)
            {
                //TODO: Speichern
                return RedirectToAction(nameof(Index));
            }

            return View(authorCreateVm);
        }

        #endregion
    }
}
