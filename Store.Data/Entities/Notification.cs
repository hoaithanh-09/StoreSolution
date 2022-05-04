using System;

namespace Store.Data.Entities.Common
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public int CustomerId { get; set; }
        public int ShipperId { get; set; }
        public Customer Customer { get; set; }
        public Shipper Shipper { get; set; }
    }
}
