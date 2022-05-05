using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class ProductPriceConfigurations : BaseConfigurations<ProductPrice>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<ProductPrice> builder)
        {
            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductPrices)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

