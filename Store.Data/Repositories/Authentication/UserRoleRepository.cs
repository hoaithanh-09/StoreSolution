using Store.Data.DataAccess;
using Store.Data.Entities;
using Store.Data.Repositories.Common;

namespace Store.Data.Repositories
{
    public interface IUserRoleRepository : IBaseRepository<UserRole>
    {
    }

    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(SqlDbContext dbContext) : base(dbContext)
        {
        }
    }
}
