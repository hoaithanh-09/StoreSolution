using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Categories
{
   public interface ICategoryService: IBaseService<Category, GetCategoryPagingRequest, CategoryViewModel, CategoryCreateRequest, CategoryUpdateRequest>
    {
    }
}
