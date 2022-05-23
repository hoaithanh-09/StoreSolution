using Store.ViewModels.Catalog.Addresses;
using Store.ViewModels.Catalog.Customers;
using Store.ViewModels.Catalog.Shippers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public int CustomerId { get; set; }
        public int ShipperId { get; set; }
        public int AddressDeliveryId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public virtual CustomerViewModel Customer { get; set; }
        public virtual ShipperViewModel Shipper { get; set; }
        public virtual AddressViewModel Address { get; set; }

    }
}
