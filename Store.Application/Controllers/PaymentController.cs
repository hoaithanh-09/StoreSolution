using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Controllers.Common;
using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Payments;

namespace Store.Application.Controllers
{

    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class PaymentController : BaseController<Payment, GetPaymentPagingRequest, PaymentViewModel, PaymentCreateRequest, PaymentUpdateRequest>
    {
        public PaymentController(IBaseService<Payment, GetPaymentPagingRequest, PaymentViewModel, PaymentCreateRequest, PaymentUpdateRequest> service) : base(service)
        {
        }
    }
}
