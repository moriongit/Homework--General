using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplication2.Models;

namespace WebApplication2.Context
{
    public class Pustokdb : IdentityDbContext
    {
        public Pustokdb(DbContextOptions<Pustokdb> opt) : base(opt) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>()
                .HasData(new Setting
                {
                    Address = "Baku, Ayna Sultanova st. 221",
                    Email = "salameleykum@mail.ru",
                   
                    Number2 = "+994773755354",
                    Logo = "~/pustok/image/logo.png",

                    Id = 1
                });
            base.OnModelCreating(modelBuilder);

        }
    }
}
