﻿using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Service;
using SchulungQotd.Shared.Models;

namespace SchulungQotd.Mvc.Controllers;

public class AuthorsController : Controller
{
    private readonly IQotdService _qotdService;

    public AuthorsController(IQotdService qotdService)
    {
        _qotdService = qotdService;
    }

    public async Task<IActionResult> Index()
    {
        var authorsVm = await _qotdService.GetAuthorsAsync();

        return View(authorsVm);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var authorVm = await _qotdService.GetAuthorByIdAsync(id);
        
        return View(authorVm);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var deletedAuthorVm = await _qotdService.DeleteAuthorAsync(id);

        if (deletedAuthorVm is not null)
        {
            //Weiterleitung
            return RedirectToAction(nameof(Index));
        }
        
        return View("Delete", deletedAuthorVm);
    }

    public ActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AuthorForCreateViewModel authorCreateVm)
    {
        if (ModelState.IsValid)
        {
            var authorVm = await _qotdService.AddAuthorAsync(authorCreateVm);

            if (authorVm is not null)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        return View(authorCreateVm);
    }
}