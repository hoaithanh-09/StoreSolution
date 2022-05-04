using Store.Data.Entities.Common;
using System;

namespace Store.Data.Entities
{
    public class Cart
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int CustomerId { get; set; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public DateTime DateCreated { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
