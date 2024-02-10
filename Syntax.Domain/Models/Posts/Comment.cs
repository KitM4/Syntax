using Syntax.Domain.Models.Actions;
using Syntax.Domain.Models.Interfaces;

namespace Syntax.Domain.Models.Posts;

public class Comment : IPost
{
    public required Guid Id { get; set; }

    public required string Content { get; set; }

    public required DateTime CreatedAt { get; set; }

    public DateTime? LastEditedAt { get; set; }

    public required string AuthorId { get; set; }

    public required virtual User Author { get; set; }

    public required Guid SnippetId { get; set; }

    public required virtual Snippet Snippet { get; set; }

    public required virtual ICollection<Like> Likes { get; set; }
}