using Syntax.Domain.Models;
using Syntax.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace Syntax.Data.Repositories;

public class UserRepository(SyntaxDbContext context) /*: IRepository<User>*/
{
    private readonly SyntaxDbContext _context = context;

    public async Task<List<User>> GetAllAsync() =>
        await _context.Users.AsNoTracking().ToListAsync();

    public async Task<List<User>> GetAllWithPropertiesAsync() =>
        await _context.Users
            .Include(user => user.Snippets)
            .Include(user => user.Reposts)
            .Include(user => user.Comments)
            .Include(user => user.Likes)
            .Include(user => user.Views)
            .Include(user => user.Followers)
            .Include(user => user.Subscriptions)
            .AsNoTracking()
            .ToListAsync();

    public async Task<User?> GetByIdAsync(string id) =>
        await _context.Users
            .Include(user => user.Snippets)
            .Include(user => user.Reposts)
            .Include(user => user.Comments)
            .Include(user => user.Likes)
            .Include(user => user.Views)
            .Include(user => user.Followers)
            .Include(user => user.Subscriptions)
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Id == id);

    public async Task UpdateByIdAsync(Guid id, User updatedEntity)
    {
        //await _context.Users.Where(user => user.Id == id.ToString())
        //    .ExecuteUpdateAsync(set => set
        //        .SetProperty(user => user.UserName, updatedEntity.UserName)
        //        .SetProperty(user => user.PasswordHash, updatedEntity.PasswordHash)
        //        .SetProperty(user => user.Bio, updatedEntity.Bio)
        //        .SetProperty(user => user.ProfileImageUrl, updatedEntity.ProfileImageUrl));

        _context.Users.Update(updatedEntity);
        await _context.SaveChangesAsync();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}