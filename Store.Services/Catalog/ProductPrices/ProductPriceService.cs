using Store.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.ProductPrices
{
    public class ProductPriceService : IProductPriceService
    {
        private readonly SqlDbContext _dbContext;
        public ProductPriceService(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
