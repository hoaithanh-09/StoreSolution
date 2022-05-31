using Store.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.OrderProducts
{
    public class OrderProductService : IOrderPrdoductService
    {
        private readonly SqlDbContext _dbContext;
        public OrderProductService(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
