using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Orders
{
    public interface IOrderService: IBaseService<Order, GetOrderPagingRequest, OrderViewModel, OrderCreateRequest, OrderUpdateRequest>
    {
    }
}
