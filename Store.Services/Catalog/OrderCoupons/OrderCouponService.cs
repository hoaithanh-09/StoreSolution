using Store.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.OrderCoupons
{
    public class OrderCouponService : IOrderCouponService
    {
        private readonly SqlDbContext _dbContext;
        public OrderCouponService(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
