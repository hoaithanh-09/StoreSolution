using AutoMapper;
using Store.Data.Entities;
using Store.Data.Infrastructures;
using Store.Data.Repositories.Common;
using Store.Services.Core;
using Store.ViewModels.Catalog.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Customers
{
    public class CustomerService : BaseService<Customer, GetCustomerPagingRequest, CustomerViewModel, CustomerCreateRequest, CustomerUpdateRequest>, ICustomerService
    {
        public CustomerService(IMapper mapper, IUnitOfWork unitOfWork, IBaseRepository<Customer> repository) : base(mapper, unitOfWork, repository)
        {
        }
    }
}
