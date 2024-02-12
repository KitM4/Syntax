using Syntax.Domain.Models.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Syntax.Data.Configurations;

public class RepostConfiguration : IEntityTypeConfiguration<Repost>
{
    public void Configure(EntityTypeBuilder<Repost> builder)
    {
        builder
            .HasKey(repost => repost.Id);

        builder
            .HasOne(repost => repost.User)
            .WithMany(user => user.Reposts)
            .HasForeignKey(repost => repost.UserId);

        builder
            .HasOne(repost => repost.Snippet)
            .WithMany(snippet => snippet.Reposts)
            .HasForeignKey(repost => repost.SnippetId);
    }
}