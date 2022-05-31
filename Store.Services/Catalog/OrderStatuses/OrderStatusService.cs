using Store.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.OrderStatuses
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly SqlDbContext _dbContext;
        public OrderStatusService(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
