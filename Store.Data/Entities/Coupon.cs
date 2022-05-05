using System;
using System.Collections.Generic;
using Store.Data.Enums;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class Coupon: BaseEntity
    {
        public string Name { get; set; }
        public CouponStatus Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeBegin { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Quantity { get; set; }
        public virtual List<OrderCoupon> OrderCoupons { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
