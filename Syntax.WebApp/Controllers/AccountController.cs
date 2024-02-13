﻿using Syntax.Data.Repositories;
using Syntax.WebApp.ViewModels.User;
using Syntax.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Syntax.WebApp.Controllers;

public class AccountController(UserRepository repository, IAccountService accountService) : Controller
{
    private readonly UserRepository _repository = repository;
    private readonly IAccountService _accountService = accountService;

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login() =>
        View(new LoginUserViewModel());

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginUserViewModel loginedUser)
    {
        if (!ModelState.IsValid)
            return View(loginedUser);

        bool result = await _accountService.LoginAsync(loginedUser.UserName, loginedUser.Password, loginedUser.RememberMe);

        if (result)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.ErrorMessage = "Login failed. Please check your username and password.";
            return View(loginedUser);
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register() =>
        View(new RegisterUserViewModel());

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterUserViewModel registeredUser)
    {
        if (!ModelState.IsValid)
            return View(registeredUser);

        try
        {
            await _accountService.RegisterAsync(registeredUser.UserName, registeredUser.Email, registeredUser.Password);
            return RedirectToAction("Index", "Home");
        }
        catch (Exception exception)
        {
            ViewBag.ErrorMessage = exception.Message;
            return View(registeredUser);
        }
    }
}