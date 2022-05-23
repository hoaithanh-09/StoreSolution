using Store.ViewModels.Catalog.Customers;
using Store.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Carts
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int ProductId { set; get; }
        public int CustomerId { get; set; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public virtual CustomerViewModel Customer { get; set; }
        public virtual ProductViewModel Product { get; set; }
    }
}
