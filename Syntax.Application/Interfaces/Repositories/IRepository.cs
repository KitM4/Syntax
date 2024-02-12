namespace Syntax.Application.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    public Task<List<T>> GetAllAsync();

    public Task<T?> GetByIdAsync(Guid id);

    public Task AddAsync(T entity);

    public Task UpdateByIdAsync(Guid id, T updatedEntity);

    public Task DeleteAsync(Guid id);
}