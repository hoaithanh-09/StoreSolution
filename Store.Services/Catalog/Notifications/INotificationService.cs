using Store.Data.Entities;
using Store.Services.Core;
using Store.ViewModels.Catalog.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Notifications
{
    public interface INotificationService : IBaseService<Notification, GetNotificationPagingRequest, NotificationViewModel, NotificationCreateRequest, NotificationUpdateRequest>
    {
    }
}
