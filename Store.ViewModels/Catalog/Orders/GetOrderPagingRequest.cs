using Store.Data.Enums;
using Store.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Orders
{
    public class GetOrderPagingRequest : PagingRequest
    {
        public int? CustomerId { get; set; }
        public int? ShipperId { get; set; }
        public OrderStatusEnums? Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
