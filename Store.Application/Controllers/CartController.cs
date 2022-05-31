using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Controllers.Common;
using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Carts;

namespace Store.Application.Controllers
{

  //  [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CartController : BaseController<Cart, GetCartPagingRequest, CartViewModel, CartCreateRequest, CartUpdateRequest>
    {
        public CartController(IBaseService<Cart, GetCartPagingRequest, CartViewModel, CartCreateRequest, CartUpdateRequest> service) : base(service)
        {
        }
    }
}
