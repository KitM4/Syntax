using Syntax.WebApp.ViewModels.Snippet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Syntax.WebApp.Controllers;

public class SnippetController : Controller
{
    [HttpGet]
    [Authorize]
    public IActionResult Create() =>
        View(new CreateSnippetViewModel());
}