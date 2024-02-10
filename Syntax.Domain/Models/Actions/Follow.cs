namespace Syntax.Domain.Models.Actions;

public class Follow
{
    public required Guid Id { get; set; }

    public required string UserId { get; set; }

    public required virtual User User { get; set; }

    public required string TargetId { get; set; }

    public required virtual User Target { get; set; }
}