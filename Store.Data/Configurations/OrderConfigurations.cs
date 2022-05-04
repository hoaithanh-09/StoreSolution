using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;
using System;

namespace Store.Data.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(X => X.CustomerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Shipper).WithMany(x => x.Orders).HasForeignKey(X => X.ShipperId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Address).WithMany(x => x.Orders).HasForeignKey(X => X.AddressDeliveryId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
