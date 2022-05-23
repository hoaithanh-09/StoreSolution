using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Details
{
    public interface IDetailService : IBaseService<Detail, GetDetailPagingRequest, DetailViewModel, DetailCreateRequest, DetailUpdateRequest>
    {
    }
}
