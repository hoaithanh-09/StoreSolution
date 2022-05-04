using System.Collections.Generic;

namespace Store.Data.Entities.Common
{
    public class Category
    {
        public int Id { get; set; }
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
