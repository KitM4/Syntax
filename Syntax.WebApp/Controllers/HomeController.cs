using System.Diagnostics;
using Syntax.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Syntax.WebApp.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Index() =>
        View();

    [HttpGet]
    [Authorize]
    public IActionResult Privacy() =>
        View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}