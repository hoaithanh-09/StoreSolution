using System.Collections.Generic;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class Address: BaseEntity
    {
        public virtual List<Customer> Customers { get; set; }
        public virtual List<Shipper> Shippers { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Supplier> Suppliers { get; set; }
    }
}
