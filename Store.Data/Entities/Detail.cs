using System.Collections.Generic;

namespace Store.Data.Entities.Common
{
    public  class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<ProductDetail> ProductDetails { get; set; }
    }
}
