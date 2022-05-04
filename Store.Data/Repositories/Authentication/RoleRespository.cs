using Store.Data.DataAccess;
using Store.Data.Entities;
using Store.Data.Repositories.Common;

namespace Store.Data.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
    }

    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(SqlDbContext dbContext) : base(dbContext)
        {
        }
    }
}
