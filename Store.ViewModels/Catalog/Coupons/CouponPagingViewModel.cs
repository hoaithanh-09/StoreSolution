using Store.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Coupons
{
    public class CouponPagingViewModel
    {
        public string Keyword { get; set; }
        public CouponStatus Type { get; set; }
        public string Name { get; set; }
      
    }
}
