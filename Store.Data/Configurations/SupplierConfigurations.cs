using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class SupplierConfigurations : BaseConfigurations<Supplier>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<Supplier> builder)
        {
            builder
                .HasOne(x => x.Address)
                .WithMany(x => x.Suppliers)
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
