using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Controllers.Common;
using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Shippers;

namespace Store.Application.Controllers
{

    //[Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ShipperController : BaseController<Shipper, GetShipperPagingRequest, ShipperViewModel, ShipperCreateRequest, ShipperUpdateRequest>
    {
        public ShipperController(IBaseService<Shipper, GetShipperPagingRequest, ShipperViewModel, ShipperCreateRequest, ShipperUpdateRequest> service) : base(service)
        {
        }
    }
}
