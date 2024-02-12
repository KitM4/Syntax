using Syntax.Domain.Models.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Syntax.Data.Configurations;

public class SnippetConfiguration : IEntityTypeConfiguration<Snippet>
{
    public void Configure(EntityTypeBuilder<Snippet> builder)
    {
        builder
            .HasKey(snippet => snippet.Id);

        builder
            .Property(snippet => snippet.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(snippet => snippet.Description)
            .HasMaxLength(250);

        builder
            .Property(snippet => snippet.Content)
            .HasMaxLength(5000)
            .IsRequired();

        builder
            .Property(snippet => snippet.Language)
            .IsRequired();

        builder
            .Property(snippet => snippet.CreatedAt)
            .IsRequired();

        builder
            .HasOne(snippet => snippet.Author)
            .WithMany(author => author.Snippets)
            .HasForeignKey(snippet => snippet.AuthorId);

        builder
            .HasMany(snippet => snippet.Likes)
            .WithOne(like => like.Snippet)
            .HasForeignKey(like => like.SnippetId);

        builder
            .HasMany(snippet => snippet.Views)
            .WithOne(view => view.Snippet)
            .HasForeignKey(view => view.SnippetId);

        builder
            .HasMany(snippet => snippet.Comments)
            .WithOne(comment => comment.Snippet)
            .HasForeignKey(comment => comment.SnippetId);

        builder
            .HasMany(snippet => snippet.Reposts)
            .WithOne(repost => repost.Snippet)
            .HasForeignKey(repost => repost.SnippetId);
    }
}