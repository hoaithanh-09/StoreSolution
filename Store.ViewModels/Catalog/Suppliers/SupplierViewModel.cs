using Store.ViewModels.Catalog.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Suppliers
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public DateTime DateCreated { get; set; } 
        public virtual AddressViewModel Address {get;set;}
    }
}
