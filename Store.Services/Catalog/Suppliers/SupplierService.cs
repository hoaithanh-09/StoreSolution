using AutoMapper;
using Store.Data.Entities;
using Store.Data.Infrastructures;
using Store.Data.Repositories.Common;
using Store.Services.Core;
using Store.ViewModels.Catalog.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Suppliers
{
    public class SupplierService : BaseService<Supplier, GetSupplierPagingRequest, SupplierViewModel, SupplierCreateRequest, SupplierUpdateRequest>, ISupplierService
    {
        public SupplierService(IMapper mapper, IUnitOfWork unitOfWork, IBaseRepository<Supplier> repository) : base(mapper, unitOfWork, repository)
        {

        }
    }
}
