using System.Collections.Generic;

namespace Store.Data.Entities.Common
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
