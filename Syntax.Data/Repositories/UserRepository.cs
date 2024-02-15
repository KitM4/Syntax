using Syntax.Domain.Models;
using Syntax.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace Syntax.Data.Repositories;

public class UserRepository(SyntaxDbContext context) /*: IRepository<User>*/
{
    private readonly SyntaxDbContext _context = context;

    public async Task<List<User>> GetAllAsync() =>
        await _context.Users.AsNoTracking().ToListAsync();

    public async Task<User?> GetById(string id) =>
        await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);

    public async Task<User?> GetByIdWithParameters(string id, params string[] parameters)
    {
        IQueryable<User> query = _context.Users.AsNoTracking();

        foreach (string parameter in parameters)
            query = query.Include(parameter);

        return await query.FirstOrDefaultAsync(user => user.Id == id);
    }

    //public async Task UpdateByIdAsync(Guid id, User updatedEntity)
    //{
    //    //await _context.Users.Where(user => user.Id == id.ToString())
    //    //    .ExecuteUpdateAsync(set => set
    //    //        .SetProperty(user => user.UserName, updatedEntity.UserName)
    //    //        .SetProperty(user => user.PasswordHash, updatedEntity.PasswordHash)
    //    //        .SetProperty(user => user.Bio, updatedEntity.Bio)
    //    //        .SetProperty(user => user.ProfileImageUrl, updatedEntity.ProfileImageUrl));

    //    _context.Users.Update(updatedEntity);
    //    await _context.SaveChangesAsync();
    //}

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}