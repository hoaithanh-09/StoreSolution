using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Carts
{
    public interface ICartService: IBaseService<Cart, GetCartPagingRequest, CartViewModel, CartCreateRequest, CartUpdateRequest>
    {
    }
}
