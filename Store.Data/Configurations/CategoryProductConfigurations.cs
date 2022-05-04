using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;
using System;

namespace Store.Data.Configurations
{
    public class CategoryProductConfigurations : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.ProductId });
            builder.HasOne(x => x.Category).WithMany(x => x.CategoryProducts).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(x => x.Product).WithMany(x => x.CategoryProducts).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
