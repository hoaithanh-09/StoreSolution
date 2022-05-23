using AutoMapper;
using Store.Data.Entities;
using Store.Data.Infrastructures;
using Store.Data.Repositories.Common;
using Store.Services.Core;
using Store.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Products
{
    public class ProductService : BaseService<Product, GetProductPagingRequest, ProductViewModel, ProductCreateRequest, ProductUpdateRequest>, IProductService
    {
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IBaseRepository<Product> repository) : base(mapper, unitOfWork, repository)
        {
        }
    }
}
