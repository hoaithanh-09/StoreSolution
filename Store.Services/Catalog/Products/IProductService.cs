using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Products
{
    public interface IProductService: IBaseService<Product, GetProductPagingRequest, ProductViewModel, ProductCreateRequest, ProductUpdateRequest>
    {
    }
}
