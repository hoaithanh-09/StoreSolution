using System.Collections.Generic;

namespace Store.Data.Entities.Common
{
    public class Address
    {
        public int Id { get; set; }
        public virtual List<Customer> Customers { get; set; }
        public virtual List<Shipper> Shippers { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Supplier> Suppliers { get; set; }

    }
}
