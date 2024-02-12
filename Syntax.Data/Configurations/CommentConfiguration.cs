using Syntax.Domain.Models.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Syntax.Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
            .HasKey(comment => comment.Id);

        builder
            .Property(comment => comment.Content)
            .HasMaxLength(150)
            .IsRequired();

        builder
            .Property(comment => comment.CreatedAt)
            .IsRequired();

        builder
            .HasOne(comment => comment.Author)
            .WithMany(author => author.Comments)
            .HasForeignKey(comment => comment.AuthorId);

        builder
            .HasOne(comment => comment.Snippet)
            .WithMany(snippet => snippet.Comments)
            .HasForeignKey(comment => comment.SnippetId);
    }
}