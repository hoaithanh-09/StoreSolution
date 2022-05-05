using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Enums;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class ProductConfigurations : BaseConfigurations<Product>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(x => x.Status)
                .HasDefaultValue(Status.Active);

            builder
                .HasOne(x => x.Supplier)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}



