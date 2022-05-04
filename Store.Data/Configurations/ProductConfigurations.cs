using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;
using Store.Data.Enums;

namespace Store.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
            builder.HasOne(x=>x.Supplier).WithMany(x=>x.Products).HasForeignKey(x=>x.SupplierId).OnDelete(DeleteBehavior.NoAction);            

        }
    }
}
