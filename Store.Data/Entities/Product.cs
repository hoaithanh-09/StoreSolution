using System;
using System.Collections.Generic;
using Store.Data.Enums;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual List<ProductDetail> ProductDetails { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
        public virtual List<ProductPrice> ProductPrices { get; set; }
        public virtual List<CategoryProduct> CategoryProducts { get; set; }
        public virtual List<Cart> Carts { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
