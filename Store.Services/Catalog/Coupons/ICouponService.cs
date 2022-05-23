using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Coupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Coupons
{
    public interface ICouponService: IBaseService<Coupon, GetCouponPagingRequest, CouponViewModel, CouponCreateRequest, CouponUpdateRequest>
    {
    }
}
