using Store.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.ProductImages
{
    public class ProductImageService : IProductImageService
    {
        private readonly SqlDbContext _dbContext;
        public ProductImageService(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
