using Microsoft.AspNetCore.Mvc;

namespace Syntax.WebApp.Controllers;

public class AccountController(IUserRepository repository) : Controller
{

}
