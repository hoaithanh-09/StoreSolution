using System;
using System.Threading.Tasks;
using Store.Data.DataAccess;
using Store.Data.Repositories;

namespace Store.Data.Infrastructures
{
    public interface IUnitOfWork: IDisposable
    {
        SqlDbContext DbContext { get; }

        #region --- Authentication ---
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IPermissionRepository Permissions { get; }
        IUserRoleRepository UserRoles { get; }
        IUserPermissionRepository UserPermissions { get; }
        IRolePermissionRepository RolePermissions { get; }
        #endregion

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }

    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly SqlDbContext _dbContext;

        #region --- Authentication ---
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IPermissionRepository _permissionRepository;
        private IUserRoleRepository _userRoleRepository;
        private IUserPermissionRepository _userPermissionRepository;
        private IRolePermissionRepository _rolePermissionRepository;
        #endregion

        public UnitOfWork(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SqlDbContext DbContext
        {
            get { return _dbContext; }
        }

        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbContext);

                return _userRepository;
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(_dbContext);

                return _roleRepository;
            }
        }

        public IPermissionRepository Permissions
        {
            get
            {
                if (_permissionRepository == null)
                    _permissionRepository = new PermissionRepository(_dbContext);

                return _permissionRepository;
            }
        }

        public IUserRoleRepository UserRoles
        {
            get
            {
                if (_userRoleRepository == null)
                    _userRoleRepository = new UserRoleRepository(_dbContext);

                return _userRoleRepository;
            }
        }

        public IUserPermissionRepository UserPermissions
        {
            get
            {
                if (_userPermissionRepository == null)
                    _userPermissionRepository = new UserPermissionRepository(_dbContext);

                return _userPermissionRepository;
            }
        }

        public IRolePermissionRepository RolePermissions
        {
            get
            {
                if (_rolePermissionRepository == null)
                    _rolePermissionRepository = new RolePermissionRepository(_dbContext);

                return _rolePermissionRepository;
            }
        }

        public int SaveChanges()
        {
            var result = DbContext.SaveChanges();
            return result;
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await DbContext.SaveChangesAsync();
            return result;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}