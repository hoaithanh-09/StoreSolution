using Store.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.ProductDetails
{
    public class ProductDetailService: IProductDetailService
    {
        private readonly SqlDbContext _dbContext;
        public ProductDetailService(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
