using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;
using Store.Data.Enums;

namespace Store.Data.Configurations
{
    public class OrderStatusConfigurations : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).HasDefaultValue(OrderStatusEnums.Pending);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderStatuses).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
