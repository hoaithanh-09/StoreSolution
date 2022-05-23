using AutoMapper;
using Store.Data.Entities;
using Store.Data.Infrastructures;
using Store.Data.Repositories.Common;
using Store.Services.Core;
using Store.ViewModels.Catalog.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Orders
{
    public class OrderService : BaseService<Order, GetOrderPagingRequest, OrderViewModel, OrderCreateRequest, OrderUpdateRequest>, IOrderService
    {
        public OrderService(IMapper mapper, IUnitOfWork unitOfWork, IBaseRepository<Order> repository) : base(mapper, unitOfWork, repository)
        {
        }
    }
}
