using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class ProductImageConfigurations : BaseConfigurations<ProductImage>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<ProductImage> builder)
        {
            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductImages)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

