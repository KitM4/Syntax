using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syntax.WebApp.ViewModels.Snippet;

namespace Syntax.WebApp.Controllers;

public class SnippetController : Controller
{
    [HttpGet]
    [Authorize]
    public IActionResult Create() =>
        View(new CreateSnippetViewModel());
}