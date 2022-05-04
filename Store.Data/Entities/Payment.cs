using System.Collections.Generic;

namespace Store.Data.Entities.Common
{
    public class Payment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<OrderPayment> OrderPayments { get; set; }
    }
}
