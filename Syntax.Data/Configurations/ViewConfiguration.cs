using Syntax.Domain.Models.Actions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Syntax.Data.Configurations;

public class ViewConfiguration : IEntityTypeConfiguration<View>
{
    public void Configure(EntityTypeBuilder<View> builder)
    {
        builder
            .HasKey(view => view.Id);

        builder
            .HasOne(view => view.User)
            .WithMany(user => user.Views)
            .HasForeignKey(view => view.UserId);

        builder
            .HasOne(view => view.Snippet)
            .WithMany(snippet => snippet.Views)
            .HasForeignKey(view => view.SnippetId);
    }
}
