using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Suppliers
{
    public interface ISupplierService: IBaseService<Supplier, GetSupplierPagingRequest, SupplierViewModel, SupplierCreateRequest, SupplierUpdateRequest>
    {
    }
}
