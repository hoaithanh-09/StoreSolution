using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Orders
{
    public class OrderUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public int CustomerId { get; set; }
        public int ShipperId { get; set; }
        public int AddressDeliveryId { get; set; }
    }
}
