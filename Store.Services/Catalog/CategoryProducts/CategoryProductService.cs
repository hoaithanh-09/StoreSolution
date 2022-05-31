using Store.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.CategoryProducts
{
    public class CategoryProductService: ICategoryProductService
    {
        private readonly SqlDbContext _dbContext;
        public CategoryProductService(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
