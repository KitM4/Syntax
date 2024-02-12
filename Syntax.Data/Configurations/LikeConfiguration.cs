using Syntax.Domain.Models.Actions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Syntax.Data.Configurations;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder
            .HasKey(like => like.Id);

        builder
            .HasOne(like => like.User)
            .WithMany(user => user.Likes)
            .HasForeignKey(like => like.UserId);

        builder
            .HasOne(like => like.Snippet)
            .WithMany(snippet => snippet.Likes)
            .HasForeignKey(like => like.SnippetId);
    }
}