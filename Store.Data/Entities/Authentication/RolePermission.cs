using System;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class RolePermission: BaseEntity
    {
        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public virtual Role Role { get; set; }

        public virtual Permission Permission { get; set; }
    }
}
