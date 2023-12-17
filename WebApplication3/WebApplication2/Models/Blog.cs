namespace WebApplication2.Models
{
    public class Blog//childofauthor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public DateTime CreatedAt { get; set; } 
        public DateTime LastUpdatedAt { get; set; }
       
        public bool? IsDeleted { get; set; }
        
        //relationship
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public ICollection<BlogTag> BlogTags { get; set; }
    }
}
