namespace Syntax.Domain.Models.Actions;

public class Subscription
{
    public required Guid Id { get; set; }

    public required string SubscriberId { get; set; }

    public required virtual User Subscriber { get; set; }

    public required string TargetId { get; set; }

    public required virtual User Target { get; set; }
}