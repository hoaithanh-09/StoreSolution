using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;

namespace Store.Data.Configurations
{
    public class ProductPriceConfigurations : IEntityTypeConfiguration<ProductPrice>
    {
        public void Configure(EntityTypeBuilder<ProductPrice> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductPrices).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
