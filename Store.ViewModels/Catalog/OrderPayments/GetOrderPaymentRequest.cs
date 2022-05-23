using Store.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.OrderPayments
{
    public class GetOrderPaymentRequest: PagingRequest
    {
        public string Keyword { get; set; }
    }
}
