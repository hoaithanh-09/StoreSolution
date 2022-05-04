using System;

namespace Store.Data.Entities.Common
{
    public class OrderCoupon
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CouponId { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Order Order { get; set; }
        public virtual Coupon Coupon { get; set; }
    }
}
