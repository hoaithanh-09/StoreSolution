using System.Collections.Generic;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class Role: BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
