using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Payments
{
    public interface IPaymentService: IBaseService<Payment, GetPaymentPagingRequest, PaymentViewModel, PaymentCreateRequest, PaymentUpdateRequest>
    {
    }
}
