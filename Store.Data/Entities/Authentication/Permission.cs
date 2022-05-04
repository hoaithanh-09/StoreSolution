using System.Collections.Generic;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class Permission: BaseEntity
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
