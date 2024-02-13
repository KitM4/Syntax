namespace Syntax.Application.Interfaces.Services;

public interface IAccountService
{
    public Task<bool> LoginAsync(string userName, string password, bool rememberMe);

    public Task RegisterAsync(string userName, string email, string password);

    public Task LogoutAsync();

    public Task EditAsync(string userName, string profileImageUrl, string bio);
}