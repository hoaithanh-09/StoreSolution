using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Enums;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class OrderStatusConfigurations : BaseConfigurations<OrderStatus>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<OrderStatus> builder)
        {
            builder
                .Property(x => x.Status)
                .HasDefaultValue(OrderStatusEnums.Pending);

            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderStatuses)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
