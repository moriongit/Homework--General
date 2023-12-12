namespace WebApplication2.Models
{
    public class Author//parent of blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //relationship
        public List<Blog> Blogs { get; set; }
    }
}
