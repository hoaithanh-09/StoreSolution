using Store.Data.Enums;
using System;
using System.Collections.Generic;

namespace Store.Data.Entities.Common
{
    public class Coupon
    {
        public int Id { get; set; }
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
