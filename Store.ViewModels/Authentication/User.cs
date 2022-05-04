using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Store.ViewModels.Common;

namespace Store.ViewModels.Authentication
{
    public class LoginModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class ResponseLoginModel
    {
        public string Token { get; set; }

        public string TokenType { get; set; }

        public long ExpiresIn { get; set; }

        public int UserId { get; set; }

        public int? EmployeeId { get; set; }

        public string Fullname { get; set; }

        public List<string> PermissionList { get; set; }
    }

    public class ChangePasswordModel
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }

    public class UserAddModel
    {
        public int EmployeeId { get; set; }

        public string Fullname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

    }

    public class UserModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Fullname { get; set; }
    }

    public class UserInfoModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Fullname { get; set; }

        public RoleModel? Role { get; set; }
    }

    public class MinifyUserModel
    {
        public int Id { get; set; }

        public String Username { get; set; }
    }

    #region Utilities
    public class UserFilter: PagingFilter
    {
        [FromQuery(Name = "keyword")]
        public string Keyword { get; set; }
    }
    #endregion
}

