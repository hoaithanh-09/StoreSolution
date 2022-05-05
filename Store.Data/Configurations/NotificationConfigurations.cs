using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class NotificationConfigurations : BaseConfigurations<Notification>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<Notification> builder)
        {
            builder
                .HasOne(x => x.Customer)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Shipper)
                .WithMany(x => x.Notifications)
                .HasForeignKey(X => X.ShipperId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
