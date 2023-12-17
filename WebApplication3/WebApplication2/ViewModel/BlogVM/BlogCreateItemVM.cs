using WebApplication2.Models;
namespace WebApplication2.ViewModel.BlogVM
{
    public class BlogCreateItemVM
    {
      
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }

        public IEnumerable<int> TagId { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
