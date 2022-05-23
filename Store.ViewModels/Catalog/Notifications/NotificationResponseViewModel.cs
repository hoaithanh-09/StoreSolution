using Store.ViewModels.Catalog.Customers;
using Store.ViewModels.Catalog.Shippers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Notifications
{
    public class NotificationResponseViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CustomerId { get; set; }
        public int ShipperId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public virtual CustomerViewModel Customer {get;set;}
        public virtual ShipperViewModel Shipper { get; set; }


    }
}
