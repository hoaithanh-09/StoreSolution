using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Controllers.Common;
using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Notifications;

namespace Store.Application.Controllers
{

   // [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class NotificationController : BaseController<Notification, GetNotificationPagingRequest, NotificationViewModel, NotificationCreateRequest, NotificationUpdateRequest>
    {
        public NotificationController(IBaseService<Notification, GetNotificationPagingRequest, NotificationViewModel, NotificationCreateRequest, NotificationUpdateRequest> service) : base(service)
        {
        }
    }
}
