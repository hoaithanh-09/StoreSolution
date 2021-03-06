using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Categories
{
    public class CategoryUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public bool IsShowed { get; set; }
    }
}
