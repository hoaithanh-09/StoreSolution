using Store.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Shippers
{
    public class GetShipperPagingRequest: PagingRequest
    {
        public string Name { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

    }
}
