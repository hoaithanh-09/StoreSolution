using Store.Data.DataAccess;
using Store.Data.Entities;
using Store.Data.Repositories.Common;

namespace Store.Data.Repositories
{
    public interface IUserPermissionRepository : IBaseRepository<UserPermission>
    {
    }

    public class UserPermissionRepository : BaseRepository<UserPermission>, IUserPermissionRepository
    {
        public UserPermissionRepository(SqlDbContext dbContext) : base(dbContext)
        {
        }
    }
}
