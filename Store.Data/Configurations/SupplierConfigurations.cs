using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;

namespace Store.Data.Configurations
{
    public class SupplierConfigurations : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x => x.Address).WithMany(x => x.Suppliers).HasForeignKey(x => x.AddressId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
