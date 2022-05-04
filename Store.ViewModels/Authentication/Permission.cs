using System;
using System.Collections.Generic;

namespace Store.ViewModels.Authentication
{
    public class PermissionAddModel
    {
        public string Code { get; set; }

        public string Description { get; set; }
    }

    public class PermissionUpdateModel: PermissionAddModel
    {
    }

    public class PermissionModel: PermissionUpdateModel
    {
        public int Id { get; set; }
    }

    public class AddPermissionToUserModel
    {
        public List<int> Ids { get; set; }
    }

    public class RemovePermissionOfUserModel
    {
        public List<int> Ids { get; set; }
    }
}

