using Store.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Categories
{
    public class GetCategoryPagingRequest: PagingRequest
    {
        public bool? IsShowed { get; set; }
        public string Keyword { get; set; }
    }
}
