namespace Store.Data.Entities
{
    public class CategoryProduct
    {
        public int ProductId { get; set;}
        public int CategoryId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }
}
