using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class Notification: BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CustomerId { get; set; }
        public int ShipperId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Shipper Shipper { get; set; }
    }
}
