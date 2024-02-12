using Syntax.Application.Interfaces.Services;

namespace Syntax.Application.Services;

public class AccountService : IAccountService
{
    public Task LoginAsync(string email, string password)
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

    public Task RegisterAsync(string userName, string email, string password)
    {
        throw new NotImplementedException();
    }
}