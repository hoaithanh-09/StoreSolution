using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;
using System;

namespace Store.Data.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x => x.Address).WithMany(x => x.Customers).HasForeignKey(x => x.AddressId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
