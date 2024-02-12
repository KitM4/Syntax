using Syntax.Domain.Models.Actions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Syntax.Data.Configurations;

public class FollowConfiguration : IEntityTypeConfiguration<Follow>
{
    public void Configure(EntityTypeBuilder<Follow> builder)
    {
        builder
            .HasKey(follow => follow.Id);

        builder
            .HasOne(follow => follow.Follower)
            .WithMany(follower => follower.Followers)
            .HasForeignKey(follow => follow.FollowerId);

        builder
            .HasOne(follow => follow.Target)
            .WithMany()
            .HasForeignKey(follow => follow.TargetId);
    }
}