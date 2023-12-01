using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplication2.Models;

namespace WebApplication2.Context
{
    public class Pustokdb : DbContext
    {
        public DbSet<Slider>Sliders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-OA1RSIR\SQLEXPRESS; Database = Pustok; Trusted_Connection = true");
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}
