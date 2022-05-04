using System;
using System.Linq;
using System.Collections.Generic;
using Store.Data.Constants;
using Store.Data.Entities;
using Store.ViewModels.Authentication;

namespace Store.Services.Utilities
{
    public static class AuthUtilities
    {
        public static List<RoleWithLevel> RoleWithLevels = new List<RoleWithLevel>
        {
            new RoleWithLevel()
            {
                Role = AuthConstants.ADMIN_ROLE,
                Level = 1,
            },
        };

        public static Role? CompareLevelOfRole(Role roleOne, Role roleTwo)
        {
            var roleWithLevelOne = RoleWithLevels.FirstOrDefault(_ => _.Role == roleOne.Name);
            var roleWithLevelTwo = RoleWithLevels.FirstOrDefault(_ => _.Role == roleTwo.Name);
            if (roleWithLevelOne != null && roleWithLevelTwo != null)
            {
                if (roleWithLevelOne.Level < roleWithLevelTwo.Level)
                {
                    return roleOne;
                }
                else
                {
                    return roleTwo;
                }
            }

            return null;
        }

        public static string GeneratePasswordForAllUser()
        {
            var time = DateTime.Now.Date;
            return $"{time.ToString("yyyyMMdd")}!@#";
        }

        public static bool IsValidRole(string role)
        {
            if (!string.IsNullOrEmpty(role) &&
                String.Equals(role, AuthConstants.ADMIN_ROLE, StringComparison.OrdinalIgnoreCase)
            )
            {
                return true;
            }
            return false;
        }

        public static bool IsAdmin(this UserInfoModel user)
        {
            if (user.Role != null && String.Equals(user.Role.Name, AuthConstants.ADMIN_ROLE, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}

