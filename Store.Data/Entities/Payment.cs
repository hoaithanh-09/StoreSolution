using System.Collections.Generic;
using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class Payment: BaseEntity
    {
        public string Name { get; set; }
        public virtual List<OrderPayment> OrderPayments { get; set; }
    }
}
