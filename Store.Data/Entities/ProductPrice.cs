using System;
using System.Collections.Generic;

namespace Store.Data.Entities.Common
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Amount { get; set; }
        public virtual Product Product { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; }

    }
}
