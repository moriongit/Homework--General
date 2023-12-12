using Microsoft.Extensions.Hosting;

namespace WebApplication2.Models
{
    public class Category//parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int? ParentCategoryId { get; set; }

        //relationship
        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
