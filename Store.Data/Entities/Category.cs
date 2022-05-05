using System.Collections.Generic;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public bool IsShowed { get; set; }
        public virtual List<CategoryProduct> CategoryProducts { get; set; }

    }
}
