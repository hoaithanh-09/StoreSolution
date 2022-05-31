using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Controllers.Common;
using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Orders;

namespace Store.Application.Controllers
{

  //  [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class OrderController : BaseController<Order, GetOrderPagingRequest, OrderViewModel, OrderCreateRequest, OrderUpdateRequest>
    {
        public OrderController(IBaseService<Order, GetOrderPagingRequest, OrderViewModel, OrderCreateRequest, OrderUpdateRequest> service) : base(service)
        {
        }
    }
}
