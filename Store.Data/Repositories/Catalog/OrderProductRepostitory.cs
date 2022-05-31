using Store.Data.DataAccess;
using Store.Data.Entities;
using Store.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories.Catalog
{
    public interface IOrderProductRepostitory : IBaseRepository<OrderProduct>
    {
    }
    public class OrderProductRepostitory : BaseRepository<OrderProduct>, IOrderProductRepostitory
    {
        public OrderProductRepostitory(SqlDbContext dbContext) : base(dbContext)
        {
        }
    }
}
