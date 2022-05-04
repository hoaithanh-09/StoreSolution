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

namespace Store.Services.Core
{
    public interface IPermissionService
    {
        Task<ResultModel> Create(PermissionAddModel model);

        Task<ResultModel> Update(PermissionUpdateModel model, int permissionId);

        Task<ResultModel> Delete(int permissionId);

        Task<ResultModel> Get(int permissionId);

        Task<PagingModel> GetPagedResult(int pageIndex, int pageSize);

        Task<ResultModel> AddUser(AddPermissionToUserModel model, int permissionId);

        Task<ResultModel> RemoveUser(RemovePermissionOfUserModel model, int permissionId);
    }

    public class PermissionService: IPermissionService
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _sqlDbContext;

        public PermissionService(IMapper mapper, SqlDbContext sqlDbContext)
        {
            _mapper = mapper;
            _sqlDbContext = sqlDbContext;
        }

        public async Task<ResultModel> Create(PermissionAddModel model)
        {
            var result = new ResultModel();
            try
            {
                var keyword = model.Code.ToLower();
                var found = await _sqlDbContext.Permissions.Where(_ => _.Code.ToLower() == keyword).FirstOrDefaultAsync();
                if (found != null)
                {
                    result.ErrorMessages = "Dupliated code";
                    return result;
                }

                var permission = _mapper.Map<PermissionAddModel, Permission>(model);
                _sqlDbContext.Permissions.Add(permission);
                await _sqlDbContext.SaveChangesAsync();

                result.Succeed = true;
                result.Data = permission.Id;
            }
            catch (Exception e)
            {
                result.ErrorMessages = e.Message + "\n" + (e.InnerException != null ? e.InnerException.Message : "") + "\n ***Trace*** \n" + e.StackTrace;
            }

            return result;
        }

        public async Task<ResultModel> Update(PermissionUpdateModel model, int permissionId)
        {
            var result = new ResultModel();
            try
            {
                var permission = await _sqlDbContext.Permissions.Where(_ => _.Id == permissionId).FirstOrDefaultAsync();
                if (permission == null)
                {
                    result.ErrorMessages = "Not found permission";
                    return result;
                }

                _mapper.Map<PermissionUpdateModel, Permission>(model, permission);
                _sqlDbContext.Permissions.Update(permission);
                await _sqlDbContext.SaveChangesAsync();

                result.Succeed = true;
                result.Data = permission.Id;
            }
            catch (Exception e)
            {
                result.ErrorMessages = e.Message + "\n" + (e.InnerException != null ? e.InnerException.Message : "") + "\n ***Trace*** \n" + e.StackTrace;
            }

            return result;
        }

        public async Task<ResultModel> Delete(int permissionId)
        {
            var result = new ResultModel();
            try
            {
                var permission = await _sqlDbContext.Permissions.Where(_ => _.Id == permissionId).FirstOrDefaultAsync();
                if (permission == null)
                {
                    result.ErrorMessages = "Not found";
                    return result;
                }

                if (_sqlDbContext.Entry(permission).State == EntityState.Detached)
                {
                    _sqlDbContext.Permissions.Attach(permission);
                }

                _sqlDbContext.Permissions.Remove(permission);
                await _sqlDbContext.SaveChangesAsync();

                result.Succeed = true;
                result.Data = permissionId;
            }
            catch (Exception e)
            {
                result.ErrorMessages = e.Message + "\n" + (e.InnerException != null ? e.InnerException.Message : "") + "\n ***Trace*** \n" + e.StackTrace;
            }

            return result;
        }

        public async Task<ResultModel> Get(int permissionId)
        {
            var result = new ResultModel();
            try
            {
                var permission = await _sqlDbContext.Permissions.Where(_ => _.Id == permissionId).FirstOrDefaultAsync();

                result.Succeed = true;
                result.Data = permission;
            }
            catch (Exception e)
            {
                result.ErrorMessages = e.Message + "\n" + (e.InnerException != null ? e.InnerException.Message : "") + "\n ***Trace*** \n" + e.StackTrace;
            }

            return result;
        }

        public async Task<PagingModel> GetPagedResult(int pageIndex, int pageSize)
        {
            var result = new PagingModel()
            {
                TotalCounts = 0,
                Data = new List<PermissionModel>(),
            };

            var query = _sqlDbContext.Permissions;
            var permissions = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            var permissionModel = _mapper.Map<List<Permission>, List<PermissionModel>>(permissions);

            result.TotalCounts = await query.CountAsync();
            result.Data = permissionModel;

            return result;
        }

        public async Task<ResultModel> AddUser(AddPermissionToUserModel model, int permissionId)
        {
            var result = new ResultModel();
            try
            {
                var permission = await _sqlDbContext.Permissions.Where(_ => _.Id == permissionId).FirstOrDefaultAsync();
                if (permission == null)
                {
                    result.ErrorMessages = "Not found permission";
                    return result;
                }

                var userPermissions = new List<UserPermission>();
                foreach (var userId in model.Ids)
                {
                    var userPermission = new UserPermission()
                    {
                        PermissionId = permissionId,
                        UserId = userId,
                    };

                    userPermissions.Add(userPermission);
                }

                _sqlDbContext.UserPermissions.AddRange(userPermissions);
                await _sqlDbContext.SaveChangesAsync();

                result.Succeed = true;
                result.Data = permission.Id;
            }
            catch (Exception e)
            {
                result.ErrorMessages = e.Message + "\n" + (e.InnerException != null ? e.InnerException.Message : "") + "\n ***Trace*** \n" + e.StackTrace;
            }

            return result;
        }

        public async Task<ResultModel> RemoveUser(RemovePermissionOfUserModel model, int permissionId)
        {
            var result = new ResultModel();
            try
            {
                var permission = await _sqlDbContext.Permissions.Where(_ => _.Id == permissionId).FirstOrDefaultAsync();
                if (permission == null)
                {
                    result.ErrorMessages = "Not found permission";
                    return result;
                }

                foreach (var userId in model.Ids)
                {
                    var permissionOfUser = await _sqlDbContext.UserPermissions.Where(_ => _.PermissionId == permissionId && _.UserId == userId).ToListAsync();
                    _sqlDbContext.UserPermissions.RemoveRange(permissionOfUser);
                }

                await _sqlDbContext.SaveChangesAsync();

                result.Succeed = true;
                result.Data = permission.Id;
            }
            catch (Exception e)
            {
                result.ErrorMessages = e.Message + "\n" + (e.InnerException != null ? e.InnerException.Message : "") + "\n ***Trace*** \n" + e.StackTrace;
            }

            return result;
        }
    }
}

