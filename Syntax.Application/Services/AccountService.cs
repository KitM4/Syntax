using Syntax.Domain.Models;
using Syntax.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Syntax.Application.Services;

public class AccountService(SignInManager<User> signInManager, UserManager<User> userManager) : IAccountService
{
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<bool> LoginAsync(string userName, string password, bool rememberMe) =>
        (await _signInManager.PasswordSignInAsync(userName, password, rememberMe, false)).Succeeded;

    public Task RegisterAsync(string userName, string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task EditAsync(string userName, string profileImageUrl, string bio)
    {
        throw new NotImplementedException();
    }

    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }
}