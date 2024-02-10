namespace Syntax.Domain.Models.Posts;

public class Repost
{
    public required Guid Id { get; set; }

    public required string UserId { get; set; }
    
    public required virtual User User { get; set; }

    public required Guid SnippetId { get; set; }

    public required virtual Snippet Snippet { get; set; }
}