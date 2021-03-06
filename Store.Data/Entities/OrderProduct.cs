using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class OrderProduct: BaseEntity
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductPriceId { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public virtual ProductPrice ProductPrice { get; set; }
    }
}
