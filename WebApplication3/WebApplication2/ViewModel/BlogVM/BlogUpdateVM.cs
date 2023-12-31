﻿using WebApplication2.Models;
namespace WebApplication2.ViewModel.BlogVM
{
    public class BlogUpdateVM
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public bool? IsDeleted { get; set; }

        public IEnumerable<int>? TagId { get; set; }

        public int AuthorID { get; set; }
        public Author? Author { get; set; }
        
    }
}
