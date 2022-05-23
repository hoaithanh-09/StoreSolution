using AutoMapper;
using Store.Data.Entities;
using Store.Data.Infrastructures;
using Store.Data.Repositories.Common;
using Store.Services.Core;
using Store.ViewModels.Catalog.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Carts
{
    public class CartService : BaseService<Cart, GetCartPagingRequest, CartViewModel, CartCreateRequest, CartUpdateRequest>, ICartService
    {
        public CartService(IMapper mapper, IUnitOfWork unitOfWork, IBaseRepository<Cart> repository) : base(mapper, unitOfWork, repository)
        {
        }
    }
}
