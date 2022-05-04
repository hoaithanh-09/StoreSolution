using Store.Data.Enums;
using System;

namespace Store.Data.Entities.Common
{
    public class OrderPayment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PaymentId { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Amount { get; set; }
        public virtual Order Order { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
