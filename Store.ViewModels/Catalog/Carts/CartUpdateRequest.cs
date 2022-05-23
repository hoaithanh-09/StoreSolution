using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Carts
{
    public class CartUpdateRequest
    {
        public int Id { get; set; }
        public int ProductId { set; get; }
        public int CustomerId { get; set; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
    }
}
