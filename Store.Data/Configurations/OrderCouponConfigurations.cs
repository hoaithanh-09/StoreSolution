using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class OrderCouponConfigurations : BaseConfigurations<OrderCoupon>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<OrderCoupon> builder)
        {
            builder
                .HasOne(x => x.Coupon)
                .WithMany(x => x.OrderCoupons)
                .HasForeignKey(x => x.CouponId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderCoupons)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

