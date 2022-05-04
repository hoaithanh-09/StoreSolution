using System;
using System.Collections.Generic;

namespace Store.ViewModels.Authentication
{
    public class RoleAddModel
    {
        public string Name { get; set; }
    }

    public class RoleUpdateModel : RoleAddModel
    {
    }

    public class RoleModel : RoleUpdateModel
    {
        public int Id { get; set; }
    }

    public class RoleDetailModel: RoleModel
    {
        public List<MinifyUserModel> Users { get; set; }
    }

    public class AddUserToRoleModel
    {
        public List<int> Ids { get; set; }
    }

    public class RemoveUserOfRoleModel
    {
        public List<int> Ids { get; set; }
    }

    public class AddPermissionToRoleModel
    {
        public List<int> Ids { get; set; }
    }

    public class RemovePermissionOfRoleModel
    {
        public List<int> Ids { get; set; }
    }

    #region Utilities
    public class RoleWithLevel
    {
        public string Role { get; set; }

        public int Level { get; set; }
    }
    #endregion
}

