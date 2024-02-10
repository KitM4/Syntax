using Syntax.Domain.Models.Posts;

namespace Syntax.Domain.Models;

public class User //TODO: get from user identity
{
    public required string Name { get; set; }

    public string? Bio { get; set; }

    //TODO: add collections
    public required virtual ICollection<Snippet> Snippets { get; set; }

    public required virtual ICollection<Repost> Reposts { get; set; }
}