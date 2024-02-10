using Syntax.Domain.Models.Actions;
using Syntax.Domain.Models.Posts;

namespace Syntax.Domain.Models;

public class User //TODO: get from user identity
{
    public required string Name { get; set; }

    public string? Bio { get; set; }

    public required virtual ICollection<Snippet> Snippets { get; set; }

    public required virtual ICollection<Repost> Reposts { get; set; }

    public required virtual ICollection<Like> Likes { get; set; }

    public required virtual ICollection<View> Views { get; set; }

    public required virtual ICollection<Follow> Followers { get; set; }

    public required virtual ICollection<Follow> Subscriptions { get; set; }
}