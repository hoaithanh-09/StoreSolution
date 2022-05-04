using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;
using System;

namespace Store.Data.Configurations
{
    public class OrderCouponConfigurations : IEntityTypeConfiguration<OrderCoupon>
    {
        public void Configure(EntityTypeBuilder<OrderCoupon> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x=>x.Coupon).WithMany(x=>x.OrderCoupons).HasForeignKey(x=>x.CouponId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderCoupons).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
