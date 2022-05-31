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
    public interface IOrderRepository: IBaseRepository<Order>
    {
    }
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(SqlDbContext dbContext) : base(dbContext)
        {
        }
    }
}
