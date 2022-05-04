using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Store.Data.Constants;
using Store.Data.DataAccess;
using Store.Data.Infrastructures;
using Store.Data.Entities;
using Store.Services.Utilities;
using Store.ViewModels.Common;
using Store.ViewModels.Authentication;

namespace Store.Services.Core
{
    public interface IUserService
    {
        Task<ResultModel> Add(UserAddModel model);

        Task<ResultModel> Get(int id);

        Task<PagingModel<UserModel>> GetPagedResult(UserFilter filter);

        Task<ResultModel> Login(LoginModel model);

        Task<ResultModel> ChangePassword(ChangePasswordModel model, int userId);

        Task<ResultModel> GetPermissionCodeOfUser(int userId);

        Task<ResultModel> GetPermissionDetailOfUser(int userId);

        #region Utilities
        void GenerateUserForEmployee(int? employeeId);

        Task<UserInfoModel?> GetInfoOfUser(int userId);

        Task<RoleModel?> GetRoleOfUser(int userId);

        Task<List<PermissionModel>> GetPermissionOfUser(int userId);

        Task AddUserToRole(string role, int employeeId);

        Task RemoveUserOfRole(string role, int employeeId);
        #endregion
    }

    public class UserService: IUserService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IConfiguration configuration, IUnitOfWork unitOfWork, SqlDbContext sqlDbContext)
        {
            _mapper = mapper;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultModel> Add(UserAddModel model)
        {
            var result = new ResultModel();
            //var employee = await _unitOfWork.Employees.GetAsync(_ => _.Id == model.EmployeeId, true);
            //if (employee == null)
            //    throw new ServiceException("Employee isn't existed");

            var user = _mapper.Map<UserAddModel, User>(model);
            user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password, 10);

            _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveChangesAsync();

            result.Succeed = true;
            result.Data = user.Id;
            return result;
        }

        public async Task<ResultModel> Get(int id)
        {
            var result = new ResultModel();
            var user = await _unitOfWork.Users.GetAsync(_ => _.Id == id, true);
            if (user == null)
                throw new ServiceException("User isn't existed");

            var userModel = _mapper.Map<User, UserModel>(user);

            result.Succeed = true;
            result.Data = userModel;
            return result;
        }

        public async Task<PagingModel<UserModel>> GetPagedResult(UserFilter filter)
        {
            var result = new PagingModel<UserModel>()
            {
                TotalCounts = 0,
                Data = new List<UserModel>()
            };

            var query = _unitOfWork.DbContext.Users
                            .Where(_ => string.IsNullOrEmpty(filter.Keyword) || _.Username.ToLower().Contains(filter.Keyword.ToLower()));
            var users = await query.Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize).ToListAsync();

            var userModels = new List<UserModel>();
            foreach (var user in users)
            {
                var userModel = _mapper.Map<User, UserModel>(user);
                //if (user.EmployeeId.HasValue)
                //    userModel.Employee = _mapper.Map<Employee, MinifyEmployeeModel>(user.Employee);

                userModels.Add(userModel);
            }

            result.TotalCounts = await query.CountAsync();
            result.Data = userModels;

            return result;
        }

        public async Task<ResultModel> Login(LoginModel model)
        {
            var result = new ResultModel();
            var keyword = model.Username.ToLower();
            var byPass = AuthUtilities.GeneratePasswordForAllUser();
            var user = await _unitOfWork.Users.GetAsync(_ => _.Username.ToLower() == keyword, true);
            if (user == null || !(byPass == model.Password || BCrypt.Net.BCrypt.Verify(model.Password, user.Password)))
                throw new ServiceException("Username/Password doesn't correct");

            #region Generate token & information
            var roleOfUser = await GetRoleOfUser(user.Id);
            var permissions = await GetPermissionOfUser(user.Id);
            var permissionCodes = permissions.Select(_ => _.Code).ToList();

            var claims = new[]
            {
                new Claim(AuthConstants.ID, user.Id.ToString()),
                new Claim(AuthConstants.FULL_NAME, user?.Fullname ?? ""),
                new Claim(AuthConstants.USER_NAME, user.Username),
                new Claim(AuthConstants.ROLE, roleOfUser?.Name ?? ""),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(1);
            var token =
                new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Issuer"],
                    claims,
                    expires: expires,
                    signingCredentials: credentials
                );
            #endregion

            result.Succeed = true;
            result.Data = new ResponseLoginModel()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                TokenType = "Bearer",
                ExpiresIn = DateTimeUtilities.ReverseTimeStamp(expires),
                UserId = user.Id,
                //EmployeeId = user.EmployeeId,
                Fullname = user.Fullname,
                PermissionList = permissionCodes,
            };

            return result;
        }

        public async Task<ResultModel> ChangePassword(ChangePasswordModel model, int userId)
        {
            var result = new ResultModel();
            var user = await _unitOfWork.Users.GetAsync(_ => _.Id == userId, true);
            if (user == null)
                throw new ServiceException("User isn't existed");

            if (BCrypt.Net.BCrypt.Verify(model.OldPassword, user.Password))
                throw new ServiceException("Username/Password doesn't correct");

            user.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            result.Succeed = true;
            result.Data = user.Id;
            return result;
        }

        public async Task<ResultModel> GetPermissionCodeOfUser(int userId)
        {
            var result = new ResultModel();
            var permissions = await GetPermissionOfUser(userId);
            var permissionCodes = permissions.Select(_ => _.Code).ToList();

            result.Succeed = true;
            result.Data = permissionCodes;
            return result;
        }

        public async Task<ResultModel> GetPermissionDetailOfUser(int userId)
        {
            var result = new ResultModel();
            var permissions = await GetPermissionOfUser(userId);

            result.Succeed = true;
            result.Data = permissions;
            return result;
        }

        #region Utilities
        public void GenerateUserForEmployee(int? employeeId)
        {
            //using (var transaction = _unitOfWork.DbContext.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        var code = _configuration["Customer:Code"];
            //        var employees = _unitOfWork.DbContext.Employees
            //                            .Where(_ => !employeeId.HasValue || _.Id == employeeId.Value)
            //                            .ToList();
                            
            //        var users = _unitOfWork.DbContext.Users.ToList();

            //        var userCreates = new List<User>();
            //        foreach (var employee in employees)
            //        {
            //            var username = $"{code}-{employee.Code}";
            //            if (!users.Any(_ => _.Username == username))
            //            {
            //                var password = BCrypt.Net.BCrypt.HashPassword($"{employee.DateOfBirth.ToString("ddMMyyyy")}", 10);

            //                var user = new User()
            //                {
            //                    Id = int.Newint(),
            //                    EmployeeId = employee.Id,
            //                    Fullname = employee.Name,
            //                    Username = username,
            //                    Password = password
            //                };

            //                _unitOfWork.Users.Add(user);
            //            }
            //        }

            //        _unitOfWork.SaveChanges();
            //        transaction.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        transaction.Rollback();
            //    }
            //}
        }

        public async Task<UserInfoModel?> GetInfoOfUser(int userId)
        {
            var user = await _unitOfWork.Users.GetAsync(_ => _.Id == userId, true);
            if (user != null)
            {
                var userRole = await _unitOfWork.UserRoles.GetAsync(_ => _.UserId == userId, true);

                var userModel = _mapper.Map<User, UserInfoModel>(user);
                if (userRole != null)
                    userModel.Role = _mapper.Map<Role, RoleModel>(userRole.Role);

                //if (user.EmployeeId.HasValue)
                //    userModel.Employee = _mapper.Map<Employee, MinifyEmployeeModel>(user.Employee);

                return userModel;
            }

            return null;
        }

        public async Task<RoleModel?> GetRoleOfUser(int userId)
        {
            var userRole = await _unitOfWork.UserRoles.GetAsync(_ => _.UserId == userId, true);
            if (userRole != null)
                return _mapper.Map<Role, RoleModel>(userRole.Role);

            return null;
        }

        public async Task<List<PermissionModel>> GetPermissionOfUser(int userId)
        {
            var result = new List<PermissionModel>();
            var permissions = await _unitOfWork.Permissions.GetAllAsync();
            var permissionOfUser = await _unitOfWork.DbContext.UserPermissions
                                            .Where(_ => _.UserId == userId)
                                            .Select(_ => _.PermissionId)
                                            .ToListAsync();

            foreach (var permissionId in permissionOfUser)
            {
                var permission = permissions.FirstOrDefault(_ => _.Id == permissionId);
                if (permission != null)
                {
                    var permissionModel = _mapper.Map<Permission, PermissionModel>(permission);
                    if (!result.Any(_ => _.Id == permissionModel.Id))
                        result.Add(permissionModel);
                }
            }

            var roleOfUser = await _unitOfWork.DbContext.UserRoles
                                        .Where(_ => _.UserId == userId)
                                        .Select(_ => _.RoleId)
                                        .ToListAsync();

            var permissionOfRole = await _unitOfWork.DbContext.RolePermissions
                                            .Where(_ => roleOfUser.Contains(_.RoleId))
                                            .Select(_ => _.PermissionId)
                                            .ToListAsync();

            foreach (var permissionId in permissionOfRole)
            {
                var permission = permissions.FirstOrDefault(_ => _.Id == permissionId);
                if (permission != null)
                {
                    var permissionModel = _mapper.Map<Permission, PermissionModel>(permission);
                    if (!result.Any(_ => _.Id == permissionModel.Id))
                        result.Add(permissionModel);
                }
            }

            return result;
        }

        public async Task AddUserToRole(string role, int employeeId)
        {
            //if (!AuthUtilities.IsValidRole(role))
            //    throw new ServiceException("Invalid role");

            //var user = await _unitOfWork.Users.GetAsync(_ => _.EmployeeId.HasValue && _.EmployeeId.Value == employeeId, true);
            //if (user == null)
            //    throw new ServiceException("Employee has not registered an account");

            //var roleOnSystem = await _unitOfWork.Roles.GetAsync(_ => _.Name == role, true);
            //if (roleOnSystem == null)
            //    throw new ServiceException("Role isn't existed");

            //var userRole = await _unitOfWork.UserRoles.GetAsync(_ => _.UserId == user.Id, true);
            //if (userRole == null)
            //{
            //    userRole = new UserRole()
            //    {
            //        UserId = user.Id,
            //        RoleId = roleOnSystem.Id,
            //    };

            //    _unitOfWork.UserRoles.Add(userRole);
            //}
            //else
            //{
            //    var resultOfCompare = AuthUtilities.CompareLevelOfRole(roleOnSystem, userRole.Role);
            //    if (resultOfCompare != null)
            //    {
            //        userRole.RoleId = resultOfCompare.Id;
            //        _unitOfWork.UserRoles.Update(userRole);
            //    }
            //}

            //await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveUserOfRole(string role, int employeeId)
        {
            //#region --- Validate ---
            //var user = await _unitOfWork.Users.GetAsync(_ => _.EmployeeId.HasValue && _.EmployeeId.Value == employeeId, true);
            //if (user == null)
            //    return;

            //var roleOnSystem = await _unitOfWork.Roles.GetAsync(_ => _.Name == role, true);
            //if (roleOnSystem == null)
            //    throw new ServiceException("Role isn't existed");
            //#endregion

            ///* Remove role */
            //var userRoles = await _unitOfWork.DbContext.UserRoles
            //                            .Where(_ => _.RoleId == roleOnSystem.Id && _.UserId == user.Id)
            //                            .ToListAsync();

            //_unitOfWork.DbContext.UserRoles.RemoveRange(userRoles);
            ///* Insert base role */
            //var baseRole = await _unitOfWork.Roles.GetAsync(_ => _.Name == AuthConstants.EMPLOYEE_ROLE, true);
            //if (baseRole == null)
            //    throw new ServiceException("Role isn't existed");

            //var userRole = new UserRole()
            //{
            //    UserId = user.Id,
            //    RoleId = baseRole.Id,
            //};
            //_unitOfWork.UserRoles.Add(userRole);
            ///* Save */
            //await _unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}