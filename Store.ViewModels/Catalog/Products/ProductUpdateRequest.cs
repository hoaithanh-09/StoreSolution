using Store.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime DateUpdated { get; set; } =DateTime.Now;
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }
        public int SupplierId { get; set; }

    }
}
