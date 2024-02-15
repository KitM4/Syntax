using Microsoft.AspNetCore.Http;
using Syntax.Domain.Models;

namespace Syntax.Application.Interfaces.Services;

public interface IAccountService
{
    public Task<bool> LoginAsync(string userName, string password, bool rememberMe);

    public Task RegisterAsync(string userName, string email, string password);

    public Task EditAsync(User user, string userName, IFormFile? profileImage, string? bio);

    public Task LogoutAsync();
}