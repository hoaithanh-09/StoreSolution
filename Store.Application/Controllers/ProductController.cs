using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Controllers.Common;
using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Products;

namespace Store.Application.Controllers
{

   // [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ProductController : BaseController<Product, GetProductPagingRequest, ProductViewModel, ProductCreateRequest, ProductUpdateRequest>
    {
        public ProductController(IBaseService<Product, GetProductPagingRequest, ProductViewModel, ProductCreateRequest, ProductUpdateRequest> service) : base(service)
        {
        }
    }
}
