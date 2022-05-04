using System;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class UserRole: BaseEntity
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
