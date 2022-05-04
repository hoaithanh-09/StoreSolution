using Store.Data.DataAccess;
using Store.Data.Entities;
using Store.Data.Repositories.Common;

namespace Store.Data.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
    }

    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(SqlDbContext dbContext): base(dbContext)
        {
        }
    }
}
