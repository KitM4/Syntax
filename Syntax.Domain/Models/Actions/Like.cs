using Syntax.Domain.Models.Posts;

namespace Syntax.Domain.Models.Actions;

public class Like
{
    public required Guid Id { get; set; }

    public required string UserId { get; set; }

    public required virtual User User { get; set; }

    public required Guid SnippetId { get; set; }

    public required virtual Snippet Snippet { get; set; }
}