namespace WebApplication2.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime LastUpdatedAt { get; set; }
        public int AuthorID { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
