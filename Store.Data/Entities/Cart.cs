using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class Cart: BaseEntity
    {
        public int ProductId { set; get; }
        public int CustomerId { get; set; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
