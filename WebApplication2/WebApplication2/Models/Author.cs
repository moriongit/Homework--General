namespace WebApplication2.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
