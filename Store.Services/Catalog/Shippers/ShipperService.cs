using AutoMapper;
using Store.Data.Entities;
using Store.Data.Infrastructures;
using Store.Data.Repositories.Common;
using Store.Services.Core;
using Store.ViewModels.Catalog.Shippers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Shippers
{
    public class ShipperService : BaseService<Shipper, GetShipperPagingRequest, ShipperViewModel, ShipperCreateRequest, ShipperUpdateRequest>, IShipperService
    {
        public ShipperService(IMapper mapper, IUnitOfWork unitOfWork, IBaseRepository<Shipper> repository) : base(mapper, unitOfWork, repository)
        {
        }
    }
}
