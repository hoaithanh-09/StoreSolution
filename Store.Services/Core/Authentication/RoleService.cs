using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Store.Data.DataAccess;
using Store.Data.Entities;
using Store.ViewModels.Common;
using Store.ViewModels.Authentication;
using Store.Services.Utilities;
using Store.Data.Infrastructures;

namespace Store.Services.Core
{
    public interface IRoleService
    {
        Task<ResultModel> Create(RoleAddModel model);

        Task<ResultModel> Update(RoleUpdateModel model, int roleId);

        Task<ResultModel> Delete(int roleId);

        Task<ResultModel> Get(int roleId);

        Task<PagingModel> GetPermission(int roleId);

        Task<PagingModel> GetPagedResult(int pageIndex, int pageSize);

        Task<ResultModel> AddUser(AddUserToRoleModel model, int roleId);

        Task<ResultModel> RemoveUser(RemoveUserOfRoleModel model, int roleId);

        Task<ResultModel> AddPermission(AddPermissionToRoleModel model, int roleId);

        Task<ResultModel> RemovePermission(RemovePermissionOfRoleModel model, int roleId);
    }

    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SqlDbContext _sqlDbContext;

        public RoleService(IMapper mapper, IUnitOfWork unitOfWork, SqlDbContext sqlDbContext)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sqlDbContext = sqlDbContext;
        }

        public async Task<ResultModel> Create(RoleAddModel model)
        {
            #region --- Validate ---
            var keyword = model.Name.ToLower();
            var found = await _sqlDbContext.Roles.Where(_ => _.Name.ToLower() == keyword).FirstOrDefaultAsync();
            if (found != null)
                throw new ServiceException("Duplicated code");
            #endregion

            var result = new ResultModel();
            var role = _mapper.Map<RoleAddModel, Role>(model);
            /* Insert */
            _unitOfWork.Roles.Add(role);
            await _sqlDbContext.SaveChangesAsync();

            result.Succeed = true;
            result.Data = role.Id;
            return result;
        }

        public async Task<ResultModel> Update(RoleUpdateModel model, int roleId)
        {
            #region --- Validate ---
            var role = await _sqlDbContext.Roles.Where(_ => _.Id == roleId).FirstOrDefaultAsync();
            if (role == null)
                throw new ServiceException("Role isn't existed");
            #endregion

            var result = new ResultModel();
            _mapper.Map<RoleUpdateModel, Role>(model, role);
            _sqlDbContext.Roles.Update(role);
            await _sqlDbContext.SaveChangesAsync();

            result.Succeed = true;
            result.Data = role.Id;
            return result;
        }

        public async Task<ResultModel> Delete(int roleId)
        {
            #region --- Validate ---
            var role = await _sqlDbContext.Roles.Where(_ => _.Id == roleId).FirstOrDefaultAsync();
            if (role == null)
                throw new ServiceException("Role isn't existed");
            #endregion

            var result = new ResultModel();
            _unitOfWork.Roles.Delete(role);
            await _sqlDbContext.SaveChangesAsync();

            result.Succeed = true;
            result.Data = roleId;
            return result;
        }

        public async Task<ResultModel> Get(int roleId)
        {
            #region --- Validate ---
            var role = await _sqlDbContext.Roles.Where(_ => _.Id == roleId).FirstOrDefaultAsync();
            if (role == null)
                throw new ServiceException("Role isn't existed");
            #endregion

            var result = new ResultModel();
            var roleModel = _mapper.Map<Role, RoleDetailModel>(role);
            roleModel.Users = new List<MinifyUserModel>();

            foreach (var userRole in role.UserRoles)
            {
                var user = await _sqlDbContext.Users.FirstOrDefaultAsync(_ => _.Id == userRole.UserId);
                var userModel = new MinifyUserModel()
                {
                    Id = user.Id,
                    Username = user.Username,
                    //Employee =
                    //    user.Employee != null
                    //    ? _mapper.Map<Employee, MinifyEmployeeModel>(user.Employee)
                    //    : null,
                };

                roleModel.Users.Add(userModel);
            }

            result.Succeed = true;
            result.Data = roleModel;
            return result;
        }

        public async Task<PagingModel> GetPermission(int roleId)
        {
            #region --- Validate ---
            var role = await _sqlDbContext.Roles.Where(_ => _.Id == roleId).FirstOrDefaultAsync();
            if (role == null)
                throw new ServiceException("Role isn't existed");
            #endregion

            var result = new PagingModel();
            var permissions = await _sqlDbContext.Permissions.ToListAsync();
            var permissionOfRole = await _sqlDbContext.RolePermissions
                                            .Where(_ => _.RoleId == roleId)
                                            .Select(_ => _.PermissionId)
                                            .ToListAsync();

            foreach (var permissionId in permissionOfRole)
            {
                var permission = permissions.FirstOrDefault(_ => _.Id == permissionId);
                if (permission != null && !result.Data.Contains(permission))
                    result.Data.Add(permission);
            }

            result.TotalCounts = result.Data.Count();
            return result;
        }

        public async Task<PagingModel> GetPagedResult(int pageIndex, int pageSize)
        {
            var result = new PagingModel();
            var query = _unitOfWork.DbContext.Roles;
            var roles = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            var roleModel = _mapper.Map<List<Role>, List<RoleModel>>(roles);

            result.TotalCounts = await query.CountAsync();
            result.Data = roleModel;
            return result;
        }

        public async Task<ResultModel> AddUser(AddUserToRoleModel model, int roleId)
        {
            #region --- Validate ---
            var role = await _sqlDbContext.Roles.Where(_ => _.Id == roleId).FirstOrDefaultAsync();
            if (role == null)
                throw new ServiceException("Role isn't existed");
            #endregion

            var result = new ResultModel();
            foreach (var userId in model.Ids)
            {
                var userRole = await _sqlDbContext.UserRoles.Where(_ => _.UserId == userId).FirstOrDefaultAsync();
                if (userRole == null)
                {
                    userRole = new UserRole()
                    {
                        UserId = userId,
                        RoleId = role.Id,
                    };

                    _unitOfWork.UserRoles.Add(userRole);
                }
                else
                {
                    var resultOfCompare = AuthUtilities.CompareLevelOfRole(role, userRole.Role);
                    if (resultOfCompare != null && resultOfCompare.Id != userRole.Role.Id)
                    {
                        userRole.RoleId = resultOfCompare.Id;
                        _unitOfWork.UserRoles.Update(userRole);
                    }
                }
            }

            await _sqlDbContext.SaveChangesAsync();

            result.Succeed = true;
            result.Data = role.Id;
            return result;
        }

        public async Task<ResultModel> RemoveUser(RemoveUserOfRoleModel model, int roleId)
        {
            #region --- Validate ---
            var role = await _sqlDbContext.Roles.Where(_ => _.Id == roleId).FirstOrDefaultAsync();
            if (role == null)
                throw new ServiceException("Role isn't existed");
            #endregion

            var result = new ResultModel();
            foreach (var userId in model.Ids)
            {
                var roleOfUser = await _sqlDbContext.UserRoles.Where(_ => _.RoleId == roleId && _.UserId == userId).ToListAsync();
                _sqlDbContext.UserRoles.RemoveRange(roleOfUser);
            }

            await _sqlDbContext.SaveChangesAsync();

            result.Succeed = true;
            result.Data = role.Id;
            return result;
        }

        public async Task<ResultModel> AddPermission(AddPermissionToRoleModel model, int roleId)
        {
            #region --- Validate ---
            var role = await _sqlDbContext.Roles.Where(_ => _.Id == roleId).FirstOrDefaultAsync();
                if (role == null)
                    throw new ServiceException("Role isn't existed");
            #endregion

            var result = new ResultModel();
            foreach (var permissionId in model.Ids)
            {
                var rolePermission = new RolePermission()
                {
                    RoleId = roleId,
                    PermissionId = permissionId,
                };

                _unitOfWork.RolePermissions.Add(rolePermission);
            }

            await _sqlDbContext.SaveChangesAsync();

            result.Succeed = true;
            result.Data = role.Id;
            return result;
        }

        public async Task<ResultModel> RemovePermission(RemovePermissionOfRoleModel model, int roleId)
        {
            #region --- Validate ---
            var role = await _sqlDbContext.Roles.Where(_ => _.Id == roleId).FirstOrDefaultAsync();
            if (role == null)
                throw new ServiceException("Role isn't existed");
            #endregion

            var result = new ResultModel();
            foreach (var permissionId in model.Ids)
            {
                var permissionOfRole = await _sqlDbContext.RolePermissions.Where(_ => _.PermissionId == permissionId && _.RoleId == roleId).ToListAsync();
                _sqlDbContext.RolePermissions.RemoveRange(permissionOfRole);
            }

            await _sqlDbContext.SaveChangesAsync();

            result.Succeed = true;
            result.Data = role.Id;
            return result;
        }
    }
}

