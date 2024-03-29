﻿namespace Syntax.Domain.Models.Actions;

public class Follow
{
    public required Guid Id { get; set; }

    public required string FollowerId { get; set; }

    public required virtual User Follower { get; set; }

    public required string TargetId { get; set; }

    public required virtual User Target { get; set; }
}