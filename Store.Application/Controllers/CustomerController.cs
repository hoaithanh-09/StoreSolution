using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Controllers.Common;
using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Customers;

namespace Store.Application.Controllers
{

    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CustomerController : BaseController<Customer, GetCustomerPagingRequest, CustomerViewModel, CustomerCreateRequest, CustomerUpdateRequest>
    {
        public CustomerController(IBaseService<Customer, GetCustomerPagingRequest, CustomerViewModel, CustomerCreateRequest, CustomerUpdateRequest> service) : base(service)
        {
        }
    }
}
