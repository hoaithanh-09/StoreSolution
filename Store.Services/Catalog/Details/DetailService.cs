using AutoMapper;
using Store.Data.Entities;
using Store.Data.Infrastructures;
using Store.Data.Repositories.Common;
using Store.Services.Core;
using Store.ViewModels.Catalog.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Details
{
    public class DetailService : BaseService<Detail, GetDetailPagingRequest, DetailViewModel, DetailCreateRequest, DetailUpdateRequest>, IDetailService
    {
        public DetailService(IMapper mapper, IUnitOfWork unitOfWork, IBaseRepository<Detail> repository) : base(mapper, unitOfWork, repository)
        {
        }
    }
}
