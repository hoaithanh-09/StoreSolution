using Store.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Coupons
{
    public class CouponCreateRequest
    {
        public string Name { get; set; }
        public CouponStatus Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeBegin { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Quantity { get; set; }
    }
}
