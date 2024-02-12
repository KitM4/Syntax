using Syntax.Domain.Models.Actions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Syntax.Data.Configurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder
            .HasKey(subscription => subscription.Id);

        builder
            .HasOne(subscription => subscription.Subscriber)
            .WithMany(subscriber => subscriber.Subscriptions)
            .HasForeignKey(subscription => subscription.SubscriberId);

        builder
            .HasOne(subscription => subscription.Target)
            .WithMany()
            .HasForeignKey(subscription => subscription.TargetId);
    }
}