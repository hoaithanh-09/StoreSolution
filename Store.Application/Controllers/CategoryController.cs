using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Controllers.Common;
using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Categories;

namespace Store.Application.Controllers
{

   // [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CategoryController : BaseController<Category, GetCategoryPagingRequest, CategoryViewModel, CategoryCreateRequest, CategoryUpdateRequest>
    {
        public CategoryController(IBaseService<Category, GetCategoryPagingRequest, CategoryViewModel, CategoryCreateRequest, CategoryUpdateRequest> service) : base(service)
        {
        }
    }
}
