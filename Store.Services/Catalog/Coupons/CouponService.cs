using AutoMapper;
using Store.Data.Entities;
using Store.Data.Infrastructures;
using Store.Data.Repositories.Common;
using Store.Services.Core;
using Store.ViewModels.Catalog.Coupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Coupons
{
    public class CouponService : BaseService<Coupon, GetCouponPagingRequest, CouponViewModel, CouponCreateRequest, CouponUpdateRequest>, ICouponService
    {
        public CouponService(IMapper mapper, IUnitOfWork unitOfWork, IBaseRepository<Coupon> repository) : base(mapper, unitOfWork, repository)
        {
        }
    }
}
