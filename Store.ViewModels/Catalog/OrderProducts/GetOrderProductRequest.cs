using Store.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.OrderProducts
{
    public class GetOrderProductRequest: PagingRequest
    {
        public string Keyword { get; set; }
    }
}
