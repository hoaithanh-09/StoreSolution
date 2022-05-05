using Store.Data.Enums;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class OrderPayment: BaseEntity
    {
        public int OrderId { get; set; }
        public int PaymentId { get; set; }
        public PaymentStatus Status { get; set; }
        public decimal Amount { get; set; }
        public virtual Order Order { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
