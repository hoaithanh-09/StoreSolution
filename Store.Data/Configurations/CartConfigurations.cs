using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;
using System;

namespace Store.Data.Configurations
{
    public class CartConfigurations : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Customer).WithMany(x=>x.Carts).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Product).WithMany(x => x.Carts).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
