using Store.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.ProductImages
{
    public class GetProductImageRequest: PagingRequest
    {
        public string Keyword { get; set; }
    }
}
