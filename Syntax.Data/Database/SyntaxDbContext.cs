using Syntax.Domain.Models;
using Syntax.Domain.Models.Posts;
using Syntax.Domain.Models.Actions;
using Syntax.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Syntax.Data.Database;

public class SyntaxDbContext(DbContextOptions<SyntaxDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Snippet> Snippets => Set<Snippet>();

    public DbSet<Repost> Reposts => Set<Repost>();

    public DbSet<Comment> Comments => Set<Comment>();

    public DbSet<Like> Likes => Set<Like>();

    public DbSet<View> Views => Set<View>();

    public DbSet<Follow> Follows => Set<Follow>();

    public DbSet<Subscription> Subscriptions => Set<Subscription>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new SnippetConfiguration());
    }
}