using Store.Data.Enums;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class ProductImage: BaseEntity
    {
        public int ProductId { get; set; }
        public ProductImageType Type { get; set; }
        public string Description { get; set; }
        public virtual Product Product { get; set; }
    }
}
