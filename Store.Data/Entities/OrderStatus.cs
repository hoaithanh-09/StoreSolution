using Store.Data.Enums;
using System;

namespace Store.Data.Entities.Common
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public OrderStatusEnums Status { get; set; }
        public string Note { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
