using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;

namespace Store.Data.Configurations
{
    public class ProductDetailConfigurations : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.DetailId });
            builder.HasOne(x => x.Product).WithMany(x => x.ProductDetails).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Detail).WithMany(x => x.ProductDetails).HasForeignKey(x => x.DetailId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
