using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.Catalog.Customers
{
    public class CustomerUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public bool Gender { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
