﻿using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplication2.Models;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
namespace WebApplication2.Context                                                     
{
    public class Pustokdb : DbContext
    {
        public Pustokdb(DbContextOptions<Pustokdb> opt) : base(opt) { }
        public DbSet<Slider>Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        internal object GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
