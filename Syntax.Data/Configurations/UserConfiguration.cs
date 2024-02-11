using Syntax.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Syntax.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(user => user.Id);

        builder
            .Property(user => user.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder
            .Property(user => user.Bio)
            .HasMaxLength(250);

        builder
            .HasMany(user => user.Snippets)
            .WithOne(snippet => snippet.Author)
            .HasForeignKey(snippet => snippet.AuthorId);

        builder
            .HasMany(user => user.Reposts)
            .WithOne(repost => repost.User)
            .HasForeignKey(repost => repost.UserId);

        builder
            .HasMany(user => user.Comments)
            .WithOne(comment => comment.Author)
            .HasForeignKey(comment => comment.AuthorId);

        builder
            .HasMany(user => user.Likes)
            .WithOne(like => like.User)
            .HasForeignKey(like => like.UserId);

        builder
            .HasMany(user => user.Views)
            .WithOne(view => view.User)
            .HasForeignKey(view => view.UserId);

        builder
            .HasMany(user => user.Followers)
            .WithOne(follow => follow.Follower)
            .HasForeignKey(follow => follow.FollowerId);

        builder
            .HasMany(user => user.Subscriptions)
            .WithOne(subscription => subscription.Subscriber)
            .HasForeignKey(subscription => subscription.SubscriberId);
    }
}