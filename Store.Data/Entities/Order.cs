using System;
using System.Collections.Generic;

namespace Store.Data.Entities.Common
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public int CustomerId { get; set; }
        public int ShipperId { get; set; }
        public int AddressDeliveryId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<OrderCoupon> OrderCoupons { get; set; }
        public virtual List<OrderPayment> OrderPayments { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; }
        public virtual List<OrderStatus> OrderStatuses { get; set; }

    }
}
