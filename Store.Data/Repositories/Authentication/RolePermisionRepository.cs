using Store.Data.DataAccess;
using Store.Data.Entities;
using Store.Data.Repositories.Common;

namespace Store.Data.Repositories
{
    public interface IRolePermissionRepository : IBaseRepository<RolePermission>
    {
    }

    public class RolePermissionRepository : BaseRepository<RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(SqlDbContext dbContext) : base(dbContext)
        {
        }
    }
}
