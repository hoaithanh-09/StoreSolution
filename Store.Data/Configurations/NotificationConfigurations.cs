using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;

namespace Store.Data.Configurations
{
    public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Customer).WithMany(x=>x.Notifications).HasForeignKey(X=>X.CustomerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Shipper).WithMany(x => x.Notifications).HasForeignKey(X => X.ShipperId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
