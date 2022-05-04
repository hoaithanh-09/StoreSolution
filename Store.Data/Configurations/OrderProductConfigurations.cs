using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;

namespace Store.Data.Configurations
{
    public class OrderProductConfigurations : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany(x => x.OrderProducts).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderProducts).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.ProductPrice).WithMany(x => x.OrderProducts).HasForeignKey(x => x.ProductPriceId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
