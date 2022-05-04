using Store.Data.Entities.Common;

namespace Store.Data.Entities
{
    public class User: BaseEntity
    {
        public string? Fullname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        public int? CustomerId { get; set; }
        public int? ShipperId { get; set; }
    }
}

