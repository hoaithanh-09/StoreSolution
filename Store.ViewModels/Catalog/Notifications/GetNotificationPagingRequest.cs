using Store.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Notifications
{
    public class GetNotificationPagingRequest: PagingRequest
    {
        public string Keyword { get; set; }
        public int? CustomerId { get; set; }
        public int? ShipperId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; } = DateTime.Now;
    }
}
