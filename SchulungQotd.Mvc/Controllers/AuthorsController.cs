﻿using Microsoft.AspNetCore.Mvc;
using SchulungQotd.Service;

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
}