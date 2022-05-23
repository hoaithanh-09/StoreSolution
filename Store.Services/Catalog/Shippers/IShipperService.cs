using Store.Services.Core;
using Store.ViewModels.Catalog.Shippers;
using Store.ViewModels.Common;
using System;
using Store.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Shippers
{
    public interface IShipperService : IBaseService<Shipper, GetShipperPagingRequest, ShipperViewModel, ShipperCreateRequest, ShipperUpdateRequest>
    {       
    
    }
}
