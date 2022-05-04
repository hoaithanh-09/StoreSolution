using Store.Data.Enums;
using System;
using System.Collections.Generic;

namespace Store.Data.Entities.Common
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdatedG { get; set; }
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
