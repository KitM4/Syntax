namespace Syntax.Domain.Models.Posts;

public class Snippet
{
    public required Guid Id { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public required string Content { get; set; }

    public required string Language { get; set; } //TODO: replase on enum

    public required DateTime CreatedAt { get; set; }

    public DateTime? LastEditedAt { get; set; }

    public required string AuthorId { get; set; }

    public required virtual User Author { get; set; }

    //TODO: add collections
}