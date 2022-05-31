using Store.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.OrderPayments
{
    public class OrderPaymentService : IOrderPaymentService
    {
        private readonly SqlDbContext _dbContext;
        public OrderPaymentService(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
