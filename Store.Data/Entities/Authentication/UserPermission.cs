using System;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class UserPermission: BaseEntity
    {
        public int UserId { get; set; }

        public int PermissionId { get; set; }

        public virtual User User { get; set; }

        public virtual Permission Permission { get; set; }
    }
}
