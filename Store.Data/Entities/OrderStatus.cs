using Store.Data.Enums;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class OrderStatus: BaseEntity
    {
        public OrderStatusEnums Status { get; set; }
        public string Note { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
