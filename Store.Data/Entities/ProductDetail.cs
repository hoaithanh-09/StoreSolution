
namespace Store.Data.Entities
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public int DetailId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Detail Detail { get; set; }
    }
}
