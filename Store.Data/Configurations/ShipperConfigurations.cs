using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Configurations
{
    public class ShipperConfigurations : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Address).WithMany(x => x.Shippers).HasForeignKey(x => x.AddressId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
