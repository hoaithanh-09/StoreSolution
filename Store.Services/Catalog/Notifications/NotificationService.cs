using AutoMapper;
using Store.Data.Entities;
using Store.Data.Infrastructures;
using Store.Data.Repositories.Common;
using Store.Services.Core;
using Store.ViewModels.Catalog.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Catalog.Notifications
{
    public class NotificationService : BaseService<Notification, GetNotificationPagingRequest, NotificationViewModel, NotificationCreateRequest, NotificationUpdateRequest>, INotificationService
    {
        public NotificationService(IMapper mapper, IUnitOfWork unitOfWork, IBaseRepository<Notification> repository) : base(mapper, unitOfWork, repository)
        {
        }
    }
}
