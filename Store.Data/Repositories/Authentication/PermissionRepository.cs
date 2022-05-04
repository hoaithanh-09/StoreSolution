using Store.Data.DataAccess;
using Store.Data.Entities;
using Store.Data.Infrastructures;
using Store.Data.Repositories.Common;

namespace Store.Data.Repositories
{
    public interface IPermissionRepository : IBaseRepository<Permission>
    {
    }

    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(SqlDbContext dbContext) : base(dbContext)
        {
        }
    }
}
