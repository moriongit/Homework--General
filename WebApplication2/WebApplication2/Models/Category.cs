namespace WebApplication2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Category> Categories { get; set;}
        public bool IsDeleted {  get; set; }
        public int ParentCategoryId {  get; set; }
    }
}
