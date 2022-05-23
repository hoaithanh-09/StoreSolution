using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Customers
{
    public interface ICustomerService : IBaseService<Customer, GetCustomerPagingRequest, CustomerViewModel, CustomerCreateRequest, CustomerUpdateRequest>
    {
    }
}

