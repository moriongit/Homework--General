namespace WebApplication2.Models
{
    public class Product//child
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool? IsDeleted { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int ProductCode { get; set; }
        public List<ProductImages> ProductImage { get; set; }
        //relationship
        public int CategoryID { get; set; }
        public Category Category { get; set; } = null!;
        


    }
}
