using System.Collections.Generic;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public  class Detail: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<ProductDetail> ProductDetails { get; set; }
    }
}
