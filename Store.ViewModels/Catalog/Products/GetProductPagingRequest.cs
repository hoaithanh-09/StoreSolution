using Store.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Products
{
    public class GetProductPagingRequest
    {
        public string Name { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public Status? Status { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
    }
}
