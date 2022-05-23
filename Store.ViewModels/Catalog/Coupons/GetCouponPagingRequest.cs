using Store.Data.Enums;
using Store.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Coupons
{
    public class GetCouponPagingRequest: PagingRequest
    {
        public CouponStatus? Type { get; set; }
        public DateTime? TimeBegin { get; set; }
        public DateTime? TimeEnd { get; set; }
    }
}
