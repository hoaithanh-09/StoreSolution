using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class OrderConfigurations: BaseConfigurations<Order>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(X => X.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Shipper)
                .WithMany(x => x.Orders)
                .HasForeignKey(X => X.ShipperId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Address)
                .WithMany(x => x.Orders)
                .HasForeignKey(X => X.AddressDeliveryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
