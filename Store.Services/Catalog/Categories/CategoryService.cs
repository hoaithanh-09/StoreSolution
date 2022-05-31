using AutoMapper;
using Store.Data.Entities;
using Store.Data.Infrastructures;
using Store.Data.Repositories.Common;
using Store.Services.Core;
using Store.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Categories
{
    public class CategoryService : BaseService<Category, GetCategoryPagingRequest, CategoryViewModel, CategoryCreateRequest, CategoryUpdateRequest>, ICategoryService
    {
        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork, IBaseRepository<Category> repository) : base(mapper, unitOfWork, repository)
        {
        }
    }
}
