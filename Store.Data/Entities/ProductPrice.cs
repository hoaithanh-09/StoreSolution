using System.Collections.Generic;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class ProductPrice: BaseEntity
    {
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public virtual Product Product { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
