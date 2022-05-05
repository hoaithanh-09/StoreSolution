using Store.Data.Enums;

namespace Store.Data.Entities.Common
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductImageType Type { get; set; }
        public string Description { get; set; }
        public virtual Product Product { get; set; }

    }
}
