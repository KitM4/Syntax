using Microsoft.Extensions.DependencyInjection;

namespace Syntax.Data.Database;

public static class DbInitializer
{
    public static void RebuildDatabase(IServiceScope scope)
    {
        SyntaxDbContext dbContext = scope.ServiceProvider.GetRequiredService<SyntaxDbContext>();

        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }
}