using Store.ViewModels.Catalog.Categories;
using Store.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.CategoryProducts
{
    public class CategoryProductViewModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public virtual ProductViewModel Product { get; set; }
        public virtual CategoryViewModel Category { get; set; }
    }
}
