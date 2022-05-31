using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Controllers.Common;
using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Suppliers;

namespace Store.Application.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class SupplierController : BaseController<Supplier, GetSupplierPagingRequest, SupplierViewModel, SupplierCreateRequest, SupplierUpdateRequest>
    {
        public SupplierController(IBaseService<Supplier, GetSupplierPagingRequest, SupplierViewModel, SupplierCreateRequest, SupplierUpdateRequest> service) : base(service)
        {
        }
    }
}
