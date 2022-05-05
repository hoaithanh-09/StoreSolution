using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class ShipperConfigurations: BaseConfigurations<Shipper>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<Shipper> builder)
        {
            builder
                .HasOne(x => x.Address)
                .WithMany(x => x.Shippers)
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
