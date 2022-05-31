using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Controllers.Common;
using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Details;

namespace Store.Application.Controllers
{

  //  [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class DetailController : BaseController<Detail, GetDetailPagingRequest, DetailViewModel, DetailCreateRequest, DetailUpdateRequest>
    {
        public DetailController(IBaseService<Detail, GetDetailPagingRequest, DetailViewModel, DetailCreateRequest, DetailUpdateRequest> service) : base(service)
        {
        }
    }
}
