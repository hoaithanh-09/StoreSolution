using AutoMapper;
using Store.Data.Entities;
using Store.Data.Infrastructures;
using Store.Data.Repositories.Common;
using Store.Services.Core;
using Store.ViewModels.Catalog.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Payments
{
    public class PaymentService : BaseService<Payment, GetPaymentPagingRequest, PaymentViewModel, PaymentCreateRequest, PaymentUpdateRequest>, IPaymentService
    {
        public PaymentService(IMapper mapper, IUnitOfWork unitOfWork, IBaseRepository<Payment> repository) : base(mapper, unitOfWork, repository)
        {
        }
    }
}
