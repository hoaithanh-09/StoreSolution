using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Controllers.Common;
using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Coupons;

namespace Store.Application.Controllers
{

    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CouponController : BaseController<Coupon, GetCouponPagingRequest, CouponViewModel, CouponCreateRequest, CouponUpdateRequest>
    {
        public CouponController(IBaseService<Coupon, GetCouponPagingRequest, CouponViewModel, CouponCreateRequest, CouponUpdateRequest> service) : base(service)
        {
        }
    }
}
