using Syntax.Domain.Models;
using System.Security.Claims;
using Syntax.Data.Repositories;
using Syntax.WebApp.ViewModels.User;
using Syntax.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Syntax.WebApp.Controllers;

public class AccountController(IAccountService accountService, UserRepository repository) : Controller
{
    private readonly IAccountService _accountService = accountService;
    private readonly UserRepository _repository = repository;

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

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
            return BadRequest();

        User? user = await _repository.GetByIdAsync(userId);
        if (user == null)
            return BadRequest();

        UserProfileViewModel userProfile = new()
        {
            UserName = user.UserName!,
            ProfileImageUrl = user.ProfileImageUrl,
            Bio = user.Bio,
            SnippetsCount = user.Snippets.Count,
            FollowersCount = user.Followers.Count,
            SubscriptionsCount = user.Subscriptions.Count,
            Snippets = user.Snippets,
        };

        return View(userProfile);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _accountService.LogoutAsync();
        return RedirectToAction("Index", "Home");
    }
}