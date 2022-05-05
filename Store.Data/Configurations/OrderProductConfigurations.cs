using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class OrderProductConfigurations : BaseConfigurations<OrderProduct>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<OrderProduct> builder)
        {
            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.OrderProducts)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderProducts)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.ProductPrice)
                .WithMany(x => x.OrderProducts)
                .HasForeignKey(x => x.ProductPriceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
