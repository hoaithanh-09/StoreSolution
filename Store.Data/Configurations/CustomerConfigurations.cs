using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class CustomerConfigurations: BaseConfigurations<Customer>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasOne(x => x.Address)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
