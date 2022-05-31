using Store.Data.DataAccess;
using Store.Data.Entities;
using Store.Data.Repositories.Common;

namespace Store.Data.Repositories.Catalog
{
    public interface IShipperRepository : IBaseRepository<Shipper>
    {
    }

    public class ShipperRepository : BaseRepository<Shipper>, IShipperRepository
    {
        public ShipperRepository(SqlDbContext dbContext) : base(dbContext)
        {
        }
    }
}
