using Syntax.Domain.Models.Interfaces;

namespace Syntax.Domain.Models.Actions;

public class Like
{
    public required Guid Id { get; set; }

    public required string UserId { get; set; }

    public required virtual User User { get; set; }

    public required Guid PostId { get; set; }

    public required virtual IPost Post { get; set; }
}