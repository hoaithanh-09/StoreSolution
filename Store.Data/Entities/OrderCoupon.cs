using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class OrderCoupon: BaseEntity
    {
        public int OrderId { get; set; }
        public int CouponId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Coupon Coupon { get; set; }
    }
}
